namespace TowerDefense.Main.Monsters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Media;
    using TowerDefense.Utils;
    using TowerDefense.Interfaces;

    public abstract class Monster : GameObject, IMonster
    {
        private List<string> imageFiles = new List<string>();
        private Point position = new Point();
        private int fileNum = 0;

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

        public int GoldValue
        {
            get;
            private set;
        }

        public int ScoreValue
        {
            get;
            private set;
        }

        public IRoute Route
        {
            get;
            private set;
        }

        public bool ReachedEnd
        {
            get;
            private set;
        }

        public Point Position
        {
            get { return this.position; }
            set
            {
                if (this.position.X == 0 && this.position.Y == 0)
                {
                    value = this.Route.Points.Select(p => p = new Point(p.X - this.ImageSource.Width, p.Y - this.ImageSource.Height)).First();
                }
                this.position = new Point(value.X - this.ImageSource.Width / this.ImageSource.Width, value.Y - this.ImageSource.Height / this.ImageSource.Width);
            }
        }

        public List<string> ImageFIles
        {
            get { return this.imageFiles; }
            protected set { this.imageFiles = value; }
        }

        public int FileNum
        {
            get { return this.fileNum; }
            protected set { this.fileNum = value; }
        }

        private IEnumerator<Point> enumerator;
        private DateTime lastMoved;

        public Monster(IRoute route, int speed, int health, int goldValue)
            : base(route.Points.First())
        {
            this.Speed = speed;
            this.Health = health;
            this.GoldValue = goldValue;
            this.ScoreValue = goldValue; //we use goldValue as scoreValue too
            this.Route = route;
            this.enumerator = route.Points.GetEnumerator();
            this.enumerator.MoveNext();
            this.lastMoved = DateTime.Now;
            this.ReachedEnd = false;
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
            if (this.ReachedEnd)
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
                    this.ReachedEnd = true;
                    this.IsDestroyed = true;
                    return;
                }
                this.Move();
            }
        }

        public override ImageSource ImageSource
        {
            get { return ImageFactory.CreateImage(this.ImageFIles[this.FileNum]); }
        }

        public override void Update()
        {
            if (this.FileNum < this.ImageFIles.Count - 1)
            {
                this.FileNum++;
            }
            else { this.FileNum = 0; }
        }
    }
}
