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
            return Point.DistanceBetween(this.Position, target.Position) < this.Range;
        }

        public ITarget GetClosestMonster(ICollection<ITarget> targets)
        {
            return targets.OrderBy(target => Point.DistanceBetween(this.Position, target.Position)).FirstOrDefault();
        }
    }
}
