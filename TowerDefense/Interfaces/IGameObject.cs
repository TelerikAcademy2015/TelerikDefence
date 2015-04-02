namespace TowerDefense.Interfaces
{
    public interface IGameObject : IDrawable
    {
        Point Center
        {
            get;
        }

        void Update();
    }
}
