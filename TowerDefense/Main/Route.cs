namespace TowerDefense.Main
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Media;
    using System.Windows.Shapes;
    using TowerDefense.Interfaces;

    public class Route : IRoute
    {
        private List<Point> points;

        public IEnumerable<Point> Points
        {
            get
            {
                return points;
            }
        }

        public Route(Path path)
        {
            this.points = new List<Point>();
            this.Initialize(path);
        }

        private void Initialize(Path path)
        {
            var figures = path.Data.GetFlattenedPathGeometry().Figures;

            if (!figures.Any())
            {
                throw new InvalidOperationException();
            }

            var firstPoint = figures.First().StartPoint;
            points.Add(new Point(firstPoint.X, firstPoint.Y));

            var lines = figures.Select(pathFigure => pathFigure.Segments.First()).Cast<LineSegment>();
            foreach (var line in lines)
            {
                var endPoint = line.Point;
                points.Add(new Point(endPoint.X, endPoint.Y));
            }
        }
    }
}
