namespace TowerDefense.Interfaces
{
    public interface ITarget
    {
        Point Position
        {
            get;
        }

        void TakeDamage(int damage);
    }
}
