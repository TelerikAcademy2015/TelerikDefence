using TowerDefense.Interfaces;

namespace TowerDefense.Main
{
    public abstract class Monster : GameObject, IMovable, ITarget
    {
        public int Speed
        {
            get;
            private set;
        }

        public int Health
        {
            get;
            private set;
        }

        public bool IsAlive
        {
            get;
            private set;
        }

        public Monster(Point position)
            : base(position)
        {
        }

        public void TakeDamage(int damage)
        {
            this.Health -= damage;
            if (this.Health <= 0)
            {
                this.IsAlive = false;
            }
        }

        public void Move()
        {
            throw new System.NotImplementedException();
        }
    }
}
