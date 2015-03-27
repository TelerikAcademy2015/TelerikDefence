using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TowerDefense.Interfaces;
using TowerDefense.Utils;

namespace TowerDefense.Main
{
    public class Tower1 : Tower
    {
        
        public Tower1(Point position)
            : base(position)
        {
            this.Range = 40;
            this.Rate = 100;
            this.Damage = 10;
            this.Price = 100;
        }

        public override ImageSource ImageSource
        {
            get
            {                
                return ImageFactory.CreateImage("cpp.png");
            }
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
