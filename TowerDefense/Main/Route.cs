using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Shapes;
using TowerDefense.Interfaces;

namespace TowerDefense.Main
{
    public class Route : IRoute, IDrawable // TODO: , IObjectCreator
    {
        public Route(Path path)
        {
            //throw new NotImplementedException();
        }

        public IEnumerable<Point> Points
        {
            get { throw new NotImplementedException(); }
        }

        public int Id
        {
            get { throw new NotImplementedException(); }
        }

        public Point Position
        {
            get { throw new NotImplementedException(); }
        }

        public int Depth
        {
            get { throw new NotImplementedException(); }
        }

        public ImageSource ImageSource
        {
            get { throw new NotImplementedException(); }
        }
    }
}
