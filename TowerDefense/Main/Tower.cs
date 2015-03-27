using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using TowerDefense.Interfaces;

namespace TowerDefense.Main
{
    public abstract class Tower : GameObject, IShooter
    {
        protected int range;
        protected int rate;
        protected int damage;
        protected int price;
        protected ITarget target;
        protected int projectileTimerCounter;
        protected ICollection<Projectile> projectiles = new HashSet<Projectile>();

        public Tower(Point position)
            : base(position)
        {
        }

        public int Range
        {
            get {return range;}
        }

        // in miliseconds
        public int Rate
        {
            get { return rate; }
        }

        public int Damage
        {
            get { return damage; }
        }

        public int Price
        {
            get { return price; }
        }

        public ITarget Target
        {
            get { return target; }
            protected set { target = value; }
        }

        public bool IsInRange(ITarget target)
        {
            return (this.GetDistance(target) < this.Range);
        }

        public void GetClosestMonsterForTarget(ICollection<ITarget> targets)
        {
            if (this.Target != null && !this.IsInRange(this.Target))
            {
                this.Target = null;
            }
            if (this.Target == null)
            {
                ITarget suspicious = targets.OrderBy(target => this.GetDistance(target)).FirstOrDefault();
                //if suspicious target is in Range -> make it tower target, if not tower target -> null
                if (this.IsInRange(suspicious))
                {
                    this.Target = suspicious;
                }
            }
        }

        public virtual void Shoot(ICollection<ITarget> targetsSet)
        {
            this.GetClosestMonsterForTarget(targetsSet);
        }
    }
}
