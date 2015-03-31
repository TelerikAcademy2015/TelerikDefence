using System.Collections.Generic;

namespace TowerDefense.Interfaces
{
    public interface IObjectCreator
    {
        IEnumerable<IGameObject> ProducedObjects
        {
            get;
        }
    }
}
