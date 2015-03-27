using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Shapes;
using TowerDefense.Interfaces;

namespace TowerDefense.Main
{
    public class Route : IRoute
    {
        private List<Point> points;
        public Route(Path path)
        {
            PathGeometry p = path.Data
            p.
            this.points = new List<Point>() { }; 
        }

        public IEnumerable<Point> Points
        {
            get
            {
                return null;
            }
        }
    }
}
