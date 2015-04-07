namespace TowerDefense.Interfaces
{
    public interface IProjectile : IGameObject, IMovable
    {
        int Damage
        {
            get;
        }

        ITarget Target
        {
            get;
        }
    }
}
