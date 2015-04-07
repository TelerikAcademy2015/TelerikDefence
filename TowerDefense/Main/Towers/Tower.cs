namespace TowerDefense.Main.Towers
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using TowerDefense.Interfaces;

    public abstract class Tower : GameObject, ITower
    {
        public override Point Position
        {
            get
            {
                return new Point(this.Center.X - this.BitmapSource.Width * 0.5, this.Center.Y - this.BitmapSource.Height * 0.75);
            }
        }

        public abstract int Price
        {
            get;
        }

        public abstract int Range
        {
            get;
        }

        public abstract TimeSpan Rate
        {
            get;
        }

        private TimeSpan timeElapsedSinceLastShot;
        private IList<IProjectile> projectilesProduced;

        public Tower(Point center)
            : base(center)
        {
            this.timeElapsedSinceLastShot = this.Rate;
            this.projectilesProduced = new List<IProjectile>();
        }

        public void Shoot(IEnumerable<ITarget> targets, TimeSpan elapsedTime)
        {
            TimeSpan totalTime = this.timeElapsedSinceLastShot + elapsedTime;
            if (totalTime < this.Rate)
            {
                this.timeElapsedSinceLastShot = totalTime;
                return;
            }

            ITarget closestTarget = targets.OrderBy(target => Point.DistanceBetween(this.Center, target.Center)).FirstOrDefault();
            if (closestTarget == null || this.IsInRange(closestTarget))
            {
                this.timeElapsedSinceLastShot = this.Rate;
                return;
            }

            this.timeElapsedSinceLastShot = totalTime - this.Rate;
            this.projectilesProduced.Add(this.CreateProjectile(closestTarget, timeElapsedSinceLastShot));
        }

        public IEnumerable<IProjectile> GetProducedObjects(System.TimeSpan elapsedTime)
        {
            IEnumerable<IProjectile> producedObjects = this.projectilesProduced.ToArray();
            this.projectilesProduced.Clear();
            return producedObjects;
        }

        public abstract IProjectile CreateProjectile(ITarget target, TimeSpan elapsedTime);

        private bool IsInRange(ITarget target)
        {
            return Point.DistanceBetween(this.Position, target.Position) < this.Range;
        }

        public override void Update(TimeSpan elapsedTime)
        {
        }

        IEnumerable IObjectCreator.GetProducedObjects(TimeSpan elapsedTime)
        {
            return this.GetProducedObjects(elapsedTime);
        }
    }
}
