using System.Collections.Generic;
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

            //var lines = path.RenderedGeometry.GetWidenedPathGeometry(new Pen()).Figures.OfType<PathFigure>();
            ////var lines = path.BindingGroup.Items.OfType<LineGeometry>();
            //var firstLine = lines.First();
            //points.Add(new Point(firstLine.StartPoint.X, firstLine.StartPoint.Y));
            //foreach (var line in lines)
            //{
            //    points.Add(new Point(line.EndPoint.X, line.EndPoint.Y));
            //}
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
