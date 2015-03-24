namespace TowerDefense.Interfaces
{
    public interface IShooter
    {
        void Shoot(ITarget target);

        bool IsInRange(ITarget target);
    }
}
