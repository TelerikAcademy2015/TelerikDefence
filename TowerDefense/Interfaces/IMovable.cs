namespace TowerDefense.Interfaces
{
    public interface IMovable
    {
        int Speed
        {
            get;
        }

        IRoute Route
        {
            get;
        }

        void Move();
    }
}
