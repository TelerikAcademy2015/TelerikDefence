namespace TowerDefense.Main
{
    using System;
    using System.Windows.Media;
    using TowerDefense.Interfaces;

    public abstract class Projectile : GameObject, IProjectile
    {
        public abstract int Speed
        {
            get;
        }

        public abstract int Damage
        {
            get;
        }

        public ITarget Target
        {
            get;
            private set;
        }

        public Projectile(Point center, ITarget target)
            : base(center)
        {
            this.Target = target;
        }

        public override void Update(TimeSpan elapsedTime)
        {
        }

        public void Move(TimeSpan timeElapsed)
        {
            Point difference = this.Target.Center - this.Center;
            double distanceToTarget = Point.DistanceBetween(this.Target.Center, this.Center);
            double distanceToTravel = timeElapsed.TotalSeconds * this.Speed * GameConstants.DISTANCE_PER_SECOND;
            if (distanceToTarget < distanceToTravel)
            {
                this.Center = new Point(this.Target.Center.X, this.Target.Center.Y);
                this.Target.TakeDamage(this.Damage);
                this.IsDestroyed = true;
                return;
            }

            double proportion = distanceToTravel / distanceToTarget;
            this.Center += new Point(difference.X * proportion, difference.Y * proportion);
        }
    }
}
