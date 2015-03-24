﻿using System;
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

        public ICollection<GameObject> gameObjects;
        public ICollection<IMovable> movingObjects;
        public ICollection<ITarget> targets;
        public ICollection<IShooter> shooters;

        public Engine(ICanvas canvas, IRoute route)
        {
            this.Canvas = canvas;
            this.Route = route;
            this.gameObjects = new HashSet<GameObject>();
            this.movingObjects = new HashSet<IMovable>();
            this.targets = new HashSet<ITarget>();
            this.shooters = new HashSet<IShooter>();

            CompositionTarget.Rendering += this.RenderingHandler;

            // Example
            this.AddMonster(new Ninja(new Point(50, 50)));
            this.AddMonster(new Ninja(new Point(150, 250)));
            this.AddMonster(new Ninja(new Point(250, 150)));
        }

        public void Start()
        {
            AsyncTimer timer = new AsyncTimer(200, () =>
                {
                    foreach (var gameObject in this.gameObjects)
                    {
                        gameObject.Update();
                    }
                    foreach (var movingObject in this.movingObjects)
                    {
                        movingObject.Move();
                    }
                    foreach (var shooter in this.shooters)
                    {
                        var firstTarget = this.targets.FirstOrDefault(target => shooter.IsInRange(target));
                        if (firstTarget != null)
                        {
                            shooter.Shoot(firstTarget);
                        }
                    }

                    // TODO: Clear dead
                });
            timer.Start();
        }

        public void AddGameObject(GameObject gameObject)
        {
            this.gameObjects.Add(gameObject);
        }

        public void AddMonster(Monster monster)
        {
            this.AddGameObject(monster);
            this.movingObjects.Add(monster);
            this.targets.Add(monster);
        }

        public void AddTower(Tower tower)
        {
            this.AddGameObject(tower);
            this.shooters.Add(tower);
        }
        // TODO: ... add more, implement remove when needed

        private void RenderingHandler(object sender, EventArgs e)
        {
            foreach (var gameObject in this.gameObjects)
            {
                this.Canvas.UpdateObject(gameObject);
            }
        }
    }
}
