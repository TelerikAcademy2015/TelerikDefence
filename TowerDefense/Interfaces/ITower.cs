namespace TowerDefense.Interfaces
{
    using System;

    public interface ITower : IGameObject, IShooter, IObjectCreator<IProjectile>
    {
        int Price
        {
            get;
        }

        int Range
        {
            get;
        }

        TimeSpan Rate
        {
            get;
        }

        IProjectile CreateProjectile(ITarget target, TimeSpan elapsedTime);
    }
}
