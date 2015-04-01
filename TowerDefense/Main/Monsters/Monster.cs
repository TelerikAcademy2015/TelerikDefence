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
            get
            {
                return this.reachedEnd;
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
        private bool reachedEnd;

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
            this.reachedEnd = false;
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
            if (this.reachedEnd)
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
                    this.reachedEnd = true;
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
