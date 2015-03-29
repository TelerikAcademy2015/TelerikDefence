using System;
using System.Collections.Generic;
using System.Linq;
using TowerDefense.Interfaces;

namespace TowerDefense.Main
{
    public abstract class Monster : GameObject, IMonster
    {
        public int Speed
        {
            get;
            protected set;
        }

        public int Health
        {
            get;
            protected set;
        }

        //TODO:
        //add goldValue and when a monster dies it gives gold(different monsters different ammount of gold)

        //private int goldValue;
        //public int GoldValue
        //{
        //    get;
        //    private set;
        //}

        public IRoute Route
        {
            get;
            private set;
        }

        private IEnumerator<Point> enumerator;
        private DateTime lastMoved;
        private bool reachedEnd;

        public Monster(IRoute route, int speed, int health) //int goldValue
            : base(route.Points.First())
        {
            this.Speed = speed;
            this.Health = health;
            //this.GoldValue = goldValue;
            this.Route = route;
            this.enumerator = route.Points.GetEnumerator();
            this.enumerator.MoveNext();
            this.lastMoved = DateTime.Now;
            this.reachedEnd = false;
        }

        public void TakeDamage(int damage)
        {
            this.Health -= damage;
            if (this.Health <= 0)
            {
                this.IsDestroyed = true;
            }
        }

        public void Move()
        {
            if (this.reachedEnd)
            {
                return;
            }
            Point nextPoint = enumerator.Current;
            DateTime now = DateTime.Now;
            TimeSpan timeElapsedSinceLastMove = now - this.lastMoved;
            double distanceRemainingToNextPoint = Point.DistanceBetween(this.Position, nextPoint);
            double distanceToTravel = this.Speed * timeElapsedSinceLastMove.TotalSeconds * GameConstants.DISTANCE_PER_SECOND;
            if (distanceToTravel < distanceRemainingToNextPoint)
            {
                Point vector = new Point(nextPoint.X - this.Position.X, nextPoint.Y - this.Position.Y);
                double proportion = distanceToTravel / distanceRemainingToNextPoint;
                this.Position = new Point(this.Position.X + proportion * vector.X, this.Position.Y + proportion * vector.Y);
                this.lastMoved = now;
            }
            else
            {
                this.Position = nextPoint;
                double proportion = distanceRemainingToNextPoint / distanceToTravel;
                TimeSpan timeElapsed = new TimeSpan(0, 0, 0, 0, (int)(timeElapsedSinceLastMove.Milliseconds * proportion));
                this.lastMoved = this.lastMoved.Add(timeElapsed);
                if (!this.enumerator.MoveNext())
                {
                    this.reachedEnd = true;
                    return;
                }
                this.Move();
            }
        }

        public override System.Windows.Media.ImageSource ImageSource
        {
            get { throw new NotImplementedException(); }
        }

        public override void Update()
        {
        }
    }
}
