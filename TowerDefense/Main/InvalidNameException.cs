namespace TowerDefense.Main
{
    using System;

    public class InvalidNameException : ApplicationException
    {
        public InvalidNameException()
        {
        }

        public InvalidNameException(string message)
            : base(message)
        {
        }

        public InvalidNameException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}