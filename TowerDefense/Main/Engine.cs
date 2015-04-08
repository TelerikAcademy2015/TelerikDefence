namespace TowerDefense.Main
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Media;
    using TowerDefense.Interfaces;
    using TowerDefense.Main.Monsters.Waves;

    public class Engine
    {
        public ICanvas Canvas
        {
            get;
            private set;
        }

        public IRoute Route
        {
            get;
            private set;
        }

        private IPlayer Player
        {
            get
            {
                return ApplicationContext.Instance.Player;
            }
        }

        public IMonsterWave MonsterWave
        {
            get
            {
                return ApplicationContext.Instance.MonsterWave;
            }
        }

        private bool gameStarted;
        private DateTime lastRendered;
        private ICollection<IGameObject> gameObjects;

        public Engine(ICanvas canvas, IRoute route)
        {
            this.Canvas = canvas;
            this.Route = route;
            this.gameObjects = new HashSet<IGameObject>();
            this.gameStarted = false;

            ApplicationContext.Instance.MonsterWave = new InitialMonsterWave(new TimeSpan(0, 0, GameConstants.MONSTER_GROUPS_SPAWN_TIME), new MonsterFactory(route));
        }

        public void Start()
        {
            if (!this.gameStarted)
            {
                this.gameStarted = true;
                this.lastRendered = DateTime.Now;
                CompositionTarget.Rendering += this.RenderingHandler;
            }
        }

        public void Stop()
        {
            if (this.gameStarted)
            {
                this.gameStarted = false;
                CompositionTarget.Rendering -= this.RenderingHandler;
                if (this.IsGameOver())
                {
                    IHighscoreProvider highscoreProvider = ApplicationContext.Instance.HighscoreProvider;
                    highscoreProvider.AddHighscoreEntry(this.Player);
                    highscoreProvider.Persist();
                }

            }
        }

        private void AddGameObject(IGameObject gameObject)
        {
            this.gameObjects.Add(gameObject);
            this.Canvas.AddObject(gameObject);
        }

        public bool TryAddTower(ITower tower)
        {
            if (this.CanPlaceTower(tower))
            {
                this.AddGameObject(tower);
                this.Player.Money -= tower.Price;
                return true;
            }

            return false;
        }

        private bool CanPlaceTower(ITower tower)
        {
            if (this.Player.Money < tower.Price)
            {
                return false;
            }

            Point center = tower.Center;
            double radius = (tower.BitmapSource.Width + this.Route.Width) * 0.5;
            if (center.X - radius < 0 || center.X + radius >= this.Canvas.Width || center.Y - radius < 0 || center.Y + radius >= this.Canvas.Height)
            {
                // outside of field
                return false;
            }

            Point firstPoint = this.Route.Points.First();
            var restPoints = this.Route.Points.Skip(1);
            foreach (var secondPoint in restPoints)
            {
                double distanceToFirstPoint = Point.DistanceBetween(firstPoint, center) - radius;
                double distanceToSecondPoint = Point.DistanceBetween(secondPoint, center) - radius;
                if (distanceToFirstPoint < 0 || distanceToSecondPoint < 0)
                {
                    return false;
                }

                double segmentLength = Point.DistanceBetween(firstPoint, secondPoint);
                if (distanceToSecondPoint >= segmentLength || distanceToFirstPoint >= segmentLength)
                {
                    firstPoint = secondPoint;
                    continue;
                }

                double deltaX = secondPoint.X - firstPoint.X;
                double deltaY = secondPoint.Y - firstPoint.Y;
                double distanceBetweenSegmentAndPoint = (Math.Abs((deltaY * center.X - deltaX * center.Y + secondPoint.X * firstPoint.Y - secondPoint.Y * firstPoint.X)) / segmentLength) - radius;
                if (distanceBetweenSegmentAndPoint < 0)
                {
                    return false;
                }

                firstPoint = secondPoint;
            }

            return true;
        }

        private void RemoveGameObject(IGameObject gameObject)
        {
            if (gameObject is IMonster)
            {
                if (((IMonster)gameObject).ReachedEnd)
                {
                    this.Player.Lives--;
                    if (this.IsGameOver())
                    {
                        this.Stop();
                    }
                }
                else
                {
                    this.Player.Money += ((IMonster)gameObject).GoldValue;
                    this.Player.Score += ((IMonster)gameObject).ScoreValue;
                }
            }

            this.gameObjects.Remove(gameObject);
            this.Canvas.RemoveObject(gameObject);
        }

        private void RenderingHandler(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            TimeSpan timeElapsedSinceLastUpdate = now - this.lastRendered;
            this.lastRendered = now;

            this.MonsterWave.GetProducedObjects(timeElapsedSinceLastUpdate).ToList().ForEach(monster => this.AddGameObject(monster));

            this.gameObjects.ToList().ForEach(@object => @object.Update(timeElapsedSinceLastUpdate));

            this.gameObjects.OfType<IMovable>().ToList().ForEach(movingObject => movingObject.Move(timeElapsedSinceLastUpdate));

            var targets = gameObjects.OfType<ITarget>();
            this.gameObjects.OfType<IShooter>().ToList().ForEach(shootingObject => shootingObject.Shoot(targets, timeElapsedSinceLastUpdate));

            this.gameObjects.OfType<IObjectCreator>().ToList().ForEach(
                objectCreator => objectCreator.GetProducedObjects(timeElapsedSinceLastUpdate).Cast<IGameObject>().ToList().ForEach(x => this.AddGameObject(x)));

            if (this.MonsterWave.Finished && !this.gameObjects.OfType<IMonster>().Any())
            {
                this.NextWave();
            }

            this.gameObjects.Where(x => x.IsDestroyed).ToList().ForEach(destroyedObject => this.RemoveGameObject(destroyedObject));
            this.gameObjects.ToList().ForEach(gameObject => this.Canvas.UpdateObject(gameObject));
        }

        private void NextWave()
        {
            this.MonsterWave.NextLevel();
        }

        private bool IsGameOver()
        {
            return this.Player.Lives <= 0;
        }
    }
}
