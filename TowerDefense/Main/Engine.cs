using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using TowerDefense.Interfaces;
using TowerDefense.Utils;

namespace TowerDefense.Main
{
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

        private ICollection<IGameObject> gameObjects;

        public Engine(ICanvas canvas, IRoute route)
        {
            this.Canvas = canvas;
            this.Route = route;
            this.Player = ApplicationContext.Instance.Player;
            this.gameObjects = new HashSet<IGameObject>();

            CompositionTarget.Rendering += this.RenderingHandler;

            // Example
            this.AddGameObject(new Ninja(this.Route));
            this.AddGameObject(new MonsterGirl(this.Route));
            this.AddGameObject(new MonsterGreen(this.Route));
            this.AddGameObject(new MonsterSweety(this.Route));
            this.AddGameObject(new MonsterYellow(this.Route));
            this.AddGameObject(new MonsterBabySkeleton(this.Route));
            this.AddGameObject(new MonsterBlueHarvester(this.Route));
            this.AddGameObject(new MonsterDarkGhost(this.Route));
            this.AddGameObject(new MonsterRedDemon(this.Route));
            this.AddGameObject(new NormalTower(new Point(600, 10)));
            this.AddGameObject(new SlowTower(new Point(300, 50)));
            this.AddGameObject(new FastTower(new Point(600, 300)));
            this.AddGameObject(new MegaTower(new Point(1000, 100)));
        }

        public void Start()
        {

            AsyncTimer timer = new AsyncTimer(100, () =>
                {
                    this.gameObjects.ToList().ForEach(@object => @object.Update());

                    this.gameObjects.OfType<IMovable>().ToList().ForEach(movingObject => movingObject.Move());

                    var targets = gameObjects.OfType<ITarget>();
                    this.gameObjects.OfType<IShooter>().ToList().ForEach(shootingObject => shootingObject.Shoot(targets));

                    this.gameObjects.OfType<IObjectCreator>().ToList().ForEach(
                        objectCreator => objectCreator.ProducedObjects.ToList().ForEach(x => this.gameObjects.Add(x)));
                });
            timer.Start();
        }

        public void AddGameObject(IGameObject gameObject)
        {
            this.gameObjects.Add(gameObject);
        }

        private void RemoveGameObject(IGameObject gameObject)
        {
            if (gameObject is IMonster)
            {
                this.Player.Money += ((IMonster)gameObject).GoldValue;
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
