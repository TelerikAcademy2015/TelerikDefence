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

        private ICollection<IGameObject> gameObjects;

        public Engine(ICanvas canvas, IRoute route)
        {
            this.Canvas = canvas;
            this.Route = route;
            this.gameObjects = new HashSet<IGameObject>();

            CompositionTarget.Rendering += this.RenderingHandler;

            // Example
            this.AddGameObject(new Ninja(this.Route));
            this.AddGameObject(new Tower1(new Point(300, 300)));
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

                    this.gameObjects.OfType<IObjectDestructor>().ToList().ForEach(
                        objectDestructor => objectDestructor.DestructObjects.ToList().ForEach(x => this.gameObjects.Remove(x)));
                });
            timer.Start();
        }

        public void AddGameObject(IGameObject gameObject)
        {
            this.gameObjects.Add(gameObject);
        }
        // TODO: ... add more, implement remove when needed

        private void RenderingHandler(object sender, EventArgs e)
        {
            foreach (var gameObject in this.gameObjects.ToArray())
            {
                this.Canvas.UpdateObject(gameObject);
            }
        }
    }
}
