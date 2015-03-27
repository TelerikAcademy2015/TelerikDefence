using System;
using System.Collections.Generic;
using System.Linq;
using TowerDefense.Interfaces;

namespace TowerDefense.Main
{
    public abstract class Tower : GameObject, IShooter
    {
        protected int range;
        protected int rate;
        protected int damage;
        protected int price;

        public Tower(Point position)
            : base(position)
        {
        }

        public int Range
        {
            get {return range;}
            protected set { range = value;}
        }

        // in miliseconds
        public int Rate
        {
            get { return rate; }
            protected set { rate = value; }
        }

        public int Damage
        {
            get { return damage; }
            protected set { damage = value; }
        }



        public int Price
        {
            get { return price; }
            protected set { price = value; }
        }

        public void Shoot(ITarget target)
        {
            target.TakeDamage(this.Damage);
        }

        public bool IsInRange(ITarget target)
        {
            return (this.GetDistance(target) < this.Range);
        }

        protected double GetDistance(ITarget target)
        {
            double deltaX = this.Position.X - target.Position.X;
            double deltaY = this.Position.Y - target.Position.Y;

            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }

        public ITarget GetClosestMonster(ICollection<ITarget> targets)
        {
            return targets.OrderBy(target => this.GetDistance(target)).FirstOrDefault();
        }
    }
}
