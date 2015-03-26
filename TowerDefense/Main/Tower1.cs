using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TowerDefense.Interfaces;

namespace TowerDefense.Main
{
    public class Tower1 : Tower
    {
        public override int Range
        {
            get
            {
                return 40;
            }
        }

        public override int Rate
        {
            get
            {
                return 100;
            }
        }

        public override int Damage
        {
            get
            {
                return 10;
            }
        }

        public override int Price
        {
            get {
                return 100;
            }
        }

        public override ImageSource ImageSource
        {
            get
            {
                return new BitmapImage(new Uri(Path.Combine(Environment.CurrentDirectory, "..", "..", "images", "cpp.png")));
            }
        }

        public Tower1(Point position)
            : base(position)
        {
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
