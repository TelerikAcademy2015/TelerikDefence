namespace TowerDefense.Main.Towers
{
    using System.Linq;
    using System.Collections.Generic;
    using TowerDefense.Interfaces;

    public abstract class Tower : GameObject, ITower
    {
        protected int range;
        protected int rate;
        protected int damage;
        protected int projectileSpeed;
        protected int price;
        protected string projectilePicture;
        protected ITarget target;
        protected int projectileTimerCounter;
        protected ICollection<Projectile> projectilesToAdd = new HashSet<Projectile>();

        public Tower(Point position)
            : base(position)
        {
            Point offset = new Point(-25, -100);
            this.Position += offset;
        }

        public int Range
        {
            get { return range; }
        }

        public int ProjectileSpeed
        {
            get { return projectileSpeed; }
        }

        public string ProjectilePicture
        {
            get { return projectilePicture; }
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

        public virtual IEnumerable<IGameObject> ProducedObjects
        {
            get { return projectilesToAdd; }
        }

        public bool IsInRange(ITarget target)
        {
            return Point.DistanceBetween(this.Position, target.Position) < this.Range;
        }

        public void GetClosestMonsterForTarget(IEnumerable<ITarget> targets)
        {
            if (this.Target != null && !this.IsInRange(this.Target))
            {
                this.Target = null;
            }
            if (this.Target == null)
            {
                ITarget suspicious = targets.OrderBy(target => Point.DistanceBetween(this.Position, target.Position)).FirstOrDefault();
                //if suspicious target is in Range -> make it tower target, if not tower target -> null
                if (suspicious != null && this.IsInRange(suspicious))
                {
                    this.Target = suspicious;
                    projectileTimerCounter = -1;
                }
            }
        }

        public virtual void Shoot(IEnumerable<ITarget> targetsSet)
        {
            this.GetClosestMonsterForTarget(targetsSet);
            if (this.Target != null && projectileTimerCounter < 0)
            {
                Projectile projectile = new Projectile(new Point(this.Position.X + 10, this.Position.Y + 30),
                                                        this.Damage,
                                                        this.ProjectileSpeed,
                                                        this.Target,
                                                        this.ProjectilePicture);
                projectileTimerCounter = rate / 100; //async timer value
                projectilesToAdd.Add(projectile);
            }
        }

        public override System.Windows.Media.ImageSource ImageSource
        {
            get { throw new System.NotImplementedException(); }
        }

        public override void Update()
        {
            projectileTimerCounter--;
            projectilesToAdd.Clear();
            if (this.Target != null && this.Target.IsDestroyed == true)
            {
                this.Target = null;
            }
        }
    }
}
