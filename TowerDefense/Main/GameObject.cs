using System.Windows.Media;
using TowerDefense.Interfaces;

namespace TowerDefense.Main
{
    public abstract class GameObject : IDrawable
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

        public Point Position
        {
            get;
            protected set;
        }

        public abstract ImageSource ImageSource
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

        public GameObject(Point position)
        {
            this.id = GameObject.nextId++;
            this.Position = position;
        }

        public abstract void Update();

        public static bool operator ==(GameObject first, GameObject second)
        {
            if (System.Object.ReferenceEquals(first, second))
            {
                return true;
            }

            if (((object)first == null) || ((object)second == null))
            {
                return false;
            }

            return first.id == second.id;
        }

        public static bool operator !=(GameObject first, GameObject second)
        {
            return !(first == second);
        }

        public override bool Equals(object obj)
        {
            GameObject other = obj as GameObject;
            if (other == null)
            {
                return false;
            }

            return this == other;
        }

        public override int GetHashCode()
        {
            return this.id;
        }
    }
}
