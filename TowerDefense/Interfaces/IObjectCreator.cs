namespace TowerDefense.Interfaces
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public interface IObjectCreator
    {
        IEnumerable GetProducedObjects(TimeSpan elapsedTime);
    }

    public interface IObjectCreator<T> : IObjectCreator where T: IGameObject
    {
        new IEnumerable<T> GetProducedObjects(TimeSpan elapsedTime);
    }
}
