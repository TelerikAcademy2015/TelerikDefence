using System.Collections.Generic;

namespace TowerDefense.Interfaces
{
    public interface IObjectDestructor
    {
        IEnumerable<IGameObject> DestructObjects
        {
            get;
        }
    }
}
