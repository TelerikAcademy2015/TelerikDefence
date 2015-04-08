namespace TowerDefense.Interfaces
{
    using System.Collections.Generic;

    public interface IRoute
    {
        IEnumerable<Point> Points
        {
            get;
        }

        double Width
        {
            get;
        }
    }
}
