using System.Collections.Generic;

namespace TowerDefense.Interfaces
{
    public interface IObjectCreator
    {
        IEnumerable<IDrawable> ProducedObjects
        {
            get;
        }
    }
}
