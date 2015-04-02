using System.Collections.Generic;

namespace TowerDefense.Interfaces
{
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
