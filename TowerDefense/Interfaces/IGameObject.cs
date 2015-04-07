namespace TowerDefense.Interfaces
{
    using System;

    public interface IGameObject : IDrawable
    {
        Point Center
        {
            get;
        }

        void Update(TimeSpan elapsedTime);
    }
}
