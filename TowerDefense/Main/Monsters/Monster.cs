namespace TowerDefense.Main.Monsters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Media.Imaging;
    using TowerDefense.Interfaces;
    using TowerDefense.Utils;

    public abstract class Monster : GameObject, IMonster
    {
        private static IDictionary<Direction, int> directionToRow;

        static Monster()
        {
            directionToRow = new Dictionary<Direction, int>();
            directionToRow[Direction.DOWN] = 0;
            directionToRow[Direction.LEFT] = 1;
            directionToRow[Direction.RIGHT] = 2;
            directionToRow[Direction.UP] = 3;
        }

        public override Point Position
        {
            get
            {
                return new Point(this.Center.X - this.BitmapSource.Width * 0.5, this.Center.Y - this.BitmapSource.Height * 1.0);
            }
        }

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

        public bool ReachedEnd
        {
            get;
            private set;
        }

        private BitmapSource bitmapSource;
        public override BitmapSource BitmapSource
        {
            get
            {
                return ImageFactory.CreateCroppedImage(this.bitmapSource, 4, this.SpriteColumns, directionToRow[this.currentDirection], this.currentImageIndex);
            }
        }

        protected abstract int SpriteColumns
        {
            get;
        }

        private Direction currentDirection;
        private int currentImageIndex;

        private TimeSpan elapsedTimeSinceLastImageChange;

        private IRoute route;
        private IEnumerator<Point> enumerator;

        public Monster(IRoute route, int speed, int health, int goldValue, int scoreValue, BitmapSource imageSource)
            : base(route.Points.First())
        {
            this.Speed = speed;
            this.Health = health;
            this.GoldValue = goldValue;
            this.ScoreValue = scoreValue;

            this.bitmapSource = imageSource;

            this.route = route;
            this.enumerator = route.Points.GetEnumerator();
            this.enumerator.MoveNext();
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

        public void Move(TimeSpan elapsedTime)
        {
            if (this.ReachedEnd)
            {
                return;
            }
            Point nextPoint = enumerator.Current;
            DateTime now = DateTime.Now;
            double distanceRemainingToNextPoint = Point.DistanceBetween(this.Center, nextPoint);
            double distanceToTravel = this.Speed * elapsedTime.TotalSeconds * GameConstants.DISTANCE_PER_SECOND;
            if (distanceToTravel < distanceRemainingToNextPoint)
            {
                Point vector = new Point(nextPoint.X - this.Center.X, nextPoint.Y - this.Center.Y);
                double proportion = distanceToTravel / distanceRemainingToNextPoint;
                this.UpdateDirection(vector);
                this.Center = new Point(this.Center.X + proportion * vector.X, this.Center.Y + proportion * vector.Y);
            }
            else
            {
                this.Center = nextPoint;
                double proportion = distanceRemainingToNextPoint / distanceToTravel;
                TimeSpan timeLeft = new TimeSpan(0, 0, 0, 0, (int)(elapsedTime.Milliseconds * (1 - proportion)));
                if (!this.enumerator.MoveNext())
                {
                    this.ReachedEnd = true;
                    this.IsDestroyed = true;
                    return;
                }
                this.Move(timeLeft);
            }
        }

        public override void Update(TimeSpan elapsedTime)
        {
            TimeSpan requiredTime = new TimeSpan(0,0,0,0, GameConstants.CHANGE_MONSTER_FRAME_TIME);
            TimeSpan totalTimeElapse = this.elapsedTimeSinceLastImageChange + elapsedTime;
            if (totalTimeElapse < requiredTime)
            {
                this.elapsedTimeSinceLastImageChange = totalTimeElapse;
                return;
            }

            this.elapsedTimeSinceLastImageChange = totalTimeElapse - requiredTime;
            this.currentImageIndex++;
            this.currentImageIndex %= this.SpriteColumns;
        }

        private void UpdateDirection(Point vector)
        {
            if (vector.X > vector.Y)
            {
                if (-vector.X > vector.Y)
                {
                    this.currentDirection = Direction.DOWN;
                }
                else
                {
                    this.currentDirection = Direction.RIGHT;
                }
            }
            else
            {
                if (-vector.X > vector.Y)
                {
                    this.currentDirection = Direction.LEFT;
                }
                else
                {
                    this.currentDirection = Direction.UP;
                }
            }
        }
    }
}
