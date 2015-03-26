using System;
using System.Collections.Generic;
using System.Linq;
using TowerDefense.Interfaces;

namespace TowerDefense.Main
{
    public abstract class Tower : GameObject, IShooter
    {
        public abstract int Range
        {
            get;
        }

        // in miliseconds
        public abstract int Rate
        {
            get;
        }

        public abstract int Damage
        {
            get;
        }

        public abstract int Price
        {
            get;
        }

        public Tower(Point position)
            : base(position)
        {
        }

        public void Shoot(ITarget target)
        {
            target.TakeDamage(this.Damage);
        }

        public bool IsInRange(ITarget target)
        {
            return this.GetDistance(target) < this.Range;
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
