namespace TowerDefense.Main
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Shapes;
    using TowerDefense.Interfaces;

    public class Route : IRoute
    {
        public IEnumerable<Point> Points
        {
            get;
            private set;
        }

        public double Width
        {
            get;
            private set;
        }

        public Route(Polyline path)
        {
            double offsetX = path.Margin.Left;
            double offsetY = path.Margin.Top;
            this.Points = path.Points.Select(point => new Point(point.X + offsetX, point.Y + offsetY)).ToArray();
            this.Width = path.StrokeThickness;
        }
    }
}
