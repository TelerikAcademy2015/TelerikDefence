namespace TowerDefense.Interfaces
{
    public interface ITarget : IDrawable
    {
        Point Position
        {
            get;
        }

        void TakeDamage(int damage);
    }
}
