namespace TowerDefense.Interfaces
{
    public interface ITower : IGameObject, IObjectCreator, IShooter
    {
        int Price
        {
            get;
        }
    }
}
