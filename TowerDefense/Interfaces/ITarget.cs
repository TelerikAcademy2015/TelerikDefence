namespace TowerDefense.Interfaces
{
    public interface ITarget : IGameObject
    {
        void TakeDamage(int damage);
    }
}
