namespace TowerDefense.Main
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Media;
    using TowerDefense.Interfaces;
    using TowerDefense.Utils;
    using TowerDefense.Main.Monsters;
    using TowerDefense.Main.Towers;

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

        private Player Player;
        private AsyncTimer timer;
        private ICollection<IGameObject> gameObjects;
        //private ICollection<ICollection<IGameObject>> waves;

        public Engine(ICanvas canvas, IRoute route)
        {
            this.Canvas = canvas;
            this.Route = route;
            this.Player = ApplicationContext.Instance.Player;
            this.gameObjects = new HashSet<IGameObject>();
            //this.waves = new List<ICollection<IGameObject>>();
            //this.CreateWaves();
            this.timer = new AsyncTimer(70, () =>
            {
                this.gameObjects.ToList().ForEach(@object => @object.Update());

                this.gameObjects.OfType<IMovable>().ToList().ForEach(movingObject => movingObject.Move());

                var targets = gameObjects.OfType<ITarget>();
                this.gameObjects.OfType<IShooter>().ToList().ForEach(shootingObject => shootingObject.Shoot(targets));

                this.gameObjects.OfType<IObjectCreator>().ToList().ForEach(
                    objectCreator => objectCreator.ProducedObjects.ToList().ForEach(x => this.gameObjects.Add(x)));
            });

            CompositionTarget.Rendering += this.RenderingHandler;         
        }

        public void Start()
        {
            this.timer.Start();
            // TODO: create a new button "new wave" to GameField and bind this method to it
            this.StartWave();
        }

        public void Stop()
        {
            this.timer.Stop();
        }

        public void AddGameObject(IGameObject gameObject)
        {
            this.gameObjects.Add(gameObject);
        }

        //public ICollection<IGameObject> GetNextWave()
        //{
        //    foreach (var wave in this.waves)
        //    {
        //        yield return wave;
        //    }
        //}

        public void StartWave()
        {
            ICollection<IGameObject> wave = new HashSet<IGameObject>();
            wave.Add(new MonsterBabySkeleton(this.Route));
            wave.Add(new MonsterGirl(this.Route));
            wave.Add(new MonsterGreen(this.Route));
            wave.Add(new MonsterSweety(this.Route));
            wave.Add(new MonsterYellow(this.Route));
            wave.Add(new MonsterBlueHarvester(this.Route));
            wave.Add(new MonsterDarkGhost(this.Route));
            wave.Add(new MonsterRedDemon(this.Route));
            //add monsters from wave to gameObjects
            foreach (var monster in wave)
            {
                this.gameObjects.Add(monster);
            }
        }

        //public void CreateWaves()
        //{
        //    ICollection<IGameObject> wave1 = new HashSet<IGameObject>();
        //    wave1.Add(new MonsterGirl(this.Route));
        //    wave1.Add(new MonsterGreen(this.Route));
        //    wave1.Add(new MonsterSweety(this.Route));
        //    wave1.Add(new MonsterBlueHarvester(this.Route));
        //    this.waves.Add(wave1);
        //    ICollection<IGameObject> wave2 = new HashSet<IGameObject>();
        //    wave2.Add(new MonsterGirl(this.Route));
        //    wave2.Add(new MonsterGreen(this.Route));
        //    wave2.Add(new MonsterSweety(this.Route));
        //    wave2.Add(new MonsterBlueHarvester(this.Route));
        //    this.waves.Add(wave2);
        //}

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
            double radius = (tower.ImageSource.Width + this.Route.Width) * 0.5;
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
                    this.Player.RemoveLive();
                }
                else
                {
                    this.Player.Money += ((IMonster)gameObject).GoldValue;
                    this.Player.Score += ((IMonster)gameObject).ScoreValue;
                }
            }

            this.gameObjects.Remove(gameObject);
        }

        private void RenderingHandler(object sender, EventArgs e)
        {
            this.gameObjects.ToList().ForEach(gameObject => this.Canvas.UpdateObject(gameObject));
            this.gameObjects.Where(x => x.IsDestroyed).ToList().ForEach(destroyedObject => this.RemoveGameObject(destroyedObject));
        }
    }
}
