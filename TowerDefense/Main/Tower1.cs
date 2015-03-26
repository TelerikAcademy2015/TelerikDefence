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
        public Tower1(Point position) 
            : base(position)
        {
            damage = 10;
            rate = 100;
            range = 40;
        }

        public override ImageSource ImageSource
        {
            get 
            {
                return new BitmapImage(new Uri(Path.Combine(Environment.CurrentDirectory, "..", "..", "images", "cpp.png"))); 
            }
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
