namespace TowerDefense.Main
{
    using System;

    public class MonsterNotFoundException : Exception
    {
        public MonsterNotFoundException()
        {
        }

        public MonsterNotFoundException(string message)
            : base(message)
        {
        }

        public MonsterNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}