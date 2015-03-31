namespace TowerDefense.Interfaces
{
    public interface ITower : IObjectCreator, IShooter
    {
        int Price
        {
            get;
        }
    }
}
