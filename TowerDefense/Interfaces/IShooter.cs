namespace TowerDefense.Interfaces
{
    using System;
    using System.Collections.Generic;

    public interface IShooter
    {
        void Shoot(IEnumerable<ITarget> targets, TimeSpan elapsedTime);
    }
}
