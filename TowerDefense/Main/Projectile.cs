using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using TowerDefense.Interfaces;
using TowerDefense.Utils;

namespace TowerDefense.Main
{
    public class Projectile : GameObject, IMovable
    {
        private int damage;
        private ITarget target;

        public Projectile(Point position,int damage,int speed, ITarget target, string picture) : base(position)
        {
            this.damage = damage;
            this.Speed = speed;
            this.target = target;
            this.Picture = picture;
        }

        public string Picture
        {
            get;
            private set;
        }

        public int Speed
        {
            get;
            private set;
        }

        public IRoute Route
        {
            get;
            private set;
        }

        public int Damage
        {
            get { return damage; }
        }

        public ITarget Target
        {
            get { return target; }
        }

        private Point NextPointFromTrajectory()
        {
            int deltaX = (int) (Math.Abs(this.Position.X - target.Position.X) * Speed / Point.DistanceBetween(this.Position, target.Position));
            int deltaY = (int)(Math.Abs(this.Position.Y - target.Position.Y) * Speed / Point.DistanceBetween(this.Position, target.Position));
            if (this.Position.X > target.Position.X)
            {
                deltaX *= -1;
            }
            if (this.Position.Y > target.Position.Y)
            {
                deltaY *= -1;
            }
            return new Point(deltaX, deltaY);
        }

        public override void Update()
        {
            if (Point.DistanceBetween(this.Position, this.Target.Position) < this.Speed)
            {
                this.Target.TakeDamage(this.Damage);
                this.IsDestroyed = true;
            }
            if (this.Target.IsDestroyed == true)
            {
                this.IsDestroyed = true;
            }
        }

        public void Move()
        {
            this.Position += NextPointFromTrajectory();
        }

        public override ImageSource ImageSource
        {
            get 
            {
                return ImageFactory.CreateImage(this.Picture); 
            }
        }
    }
}
