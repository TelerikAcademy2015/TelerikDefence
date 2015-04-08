namespace TowerDefense.Interfaces
{
    using System;

    public interface IMovable
    {
        int Speed
        {
            get;
        }

        void Move(TimeSpan timeElapsed);
    }
}
