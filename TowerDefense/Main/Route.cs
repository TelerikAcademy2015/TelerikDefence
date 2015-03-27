using System.Collections.Generic;
using System.Linq;
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
            this.points = new List<Point>();
            var figures = path.Data.GetFlattenedPathGeometry().Figures;
            var lines = figures.Select(pathFigure => pathFigure.Segments.First()).Cast<LineSegment>();
            var firstPoint = figures.First().StartPoint;
            points.Add(new Point(firstPoint.X, firstPoint.Y));
            foreach (var line in lines)
            {
                var endPoint = line.Point;
                points.Add(new Point(endPoint.X, endPoint.Y));
            }
        }

        public IEnumerable<Point> Points
        {
            get
            {
                return points;
            }
        }
    }
}
