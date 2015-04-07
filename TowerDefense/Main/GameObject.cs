namespace TowerDefense.Main
{
    using System;
    using System.Windows.Media.Imaging;
    using TowerDefense.Interfaces;

    public abstract class GameObject : IGameObject
    {
        private static int nextId = 0;

        private readonly int id;
        public int Id
        {
            get
            {
                return this.id;
            }
        }

        public virtual Point Position
        {
            get
            {
                return new Point(this.Center.X - this.BitmapSource.Width * 0.5, this.Center.Y - this.BitmapSource.Height * 0.5);
            }
        }

        public virtual Point Center
        {
            get;
            protected set;
        }

        public abstract BitmapSource BitmapSource
        {
            get;
        }

        public virtual int Depth
        {
            get
            {
                return 1;
            }
        }

        public bool IsDestroyed
        {
            get;
            protected set;
        }

        public GameObject(Point center)
        {
            this.id = GameObject.nextId++;
            this.Center = center;
            this.IsDestroyed = false;
        }

        public abstract void Update(TimeSpan elapsedTime);
    }
}
