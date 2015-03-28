namespace TowerDefense.Interfaces
{
    public interface IMonster : IGameObject, IMovable, ITarget
    {
        int Health
        {
            get;
        }
    }
}
