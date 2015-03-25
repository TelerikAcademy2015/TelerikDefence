using System;
using System.Collections.Generic;
using TowerDefense.Interfaces;

namespace TowerDefense.Main
{
    public abstract class Tower : GameObject, IShooter
    {
        protected int range;
        protected int damage;
        protected int rate;
        protected int price;
        protected ITarget target;

        public Tower(Point position)
            : base(position)
        {
        }

        public int Range
        {
            get { return range; }
        }

        public int Damage
        {
            get { return damage; }
        }

        public int Rate
        {
            get { return rate; }
        }

        public int Price
        {
            get { return price; }
        }

        public ITarget Target
        {
            get { return target; }
        }

        public void Shoot(ITarget target)
        {
            target.TakeDamage(this.Damage);
        }

        public bool IsInRange(ITarget target)
        {

            if (this.GetDistance(target) < this.Range)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void GetClosestMonster(ICollection<ITarget> monsters)
        {
            target = null;
            double minRange = range;

            foreach (var monster in monsters)
            {
                if (this.GetDistance(monster) < minRange)
                {
                    minRange = this.GetDistance(monster);
                    target = monster;
                }
            }
        }

    }
}
