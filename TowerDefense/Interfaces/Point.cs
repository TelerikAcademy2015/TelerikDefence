namespace TowerDefense.Interfaces
{
    using System;

    public struct Point
    {
        public readonly double X;
        public readonly double Y;

        public static double DistanceBetween(Point first, Point second)
        {
            double deltaX = first.X - second.X;
            double deltaY = first.Y - second.Y;

            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }

        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public static Point operator +(Point a, Point b)
        {
            return new Point(a.X + b.X, a.Y + b.Y);
        }

        public static Point operator -(Point a, Point b)
        {
            return new Point(a.X - b.X, a.Y - b.Y);
        }
    }
}
