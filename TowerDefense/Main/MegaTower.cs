using System.Collections.Generic;
using System.Windows.Media;
using TowerDefense.Interfaces;
using TowerDefense.Utils;

namespace TowerDefense.Main
{
    public class MegaTower : Tower
    {

        public MegaTower(Point position)
            : base(position)
        {
            this.range = 1300;
            this.rate = 600;
            this.damage = 35;
            this.price = 350;
            this.projectileSpeed = 25;
            this.projectilePicture = "projectile.png";
        }

        public override ImageSource ImageSource
        {
            get { return ImageFactory.CreateImage("ms.png"); }
        }

    }
}

