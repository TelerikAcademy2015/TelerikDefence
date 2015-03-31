namespace TowerDefense.Main
{
    using System;

    public class CreepNotFoundException : Exception
    {
        public CreepNotFoundException()
        {
        }

        public CreepNotFoundException(string message)
            : base(message)
        {
        }

        public CreepNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}