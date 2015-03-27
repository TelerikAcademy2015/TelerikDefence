using System.Collections.Generic;

namespace TowerDefense.Interfaces
{
    public interface IShooter
    {
        bool IsInRange(ITarget target);

        void Shoot(ICollection<ITarget> targets);
    }
}
