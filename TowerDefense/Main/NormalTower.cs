using System.Collections.Generic;
using System.Windows.Media;
using TowerDefense.Interfaces;
using TowerDefense.Utils;

namespace TowerDefense.Main
{
    public class NormalTower : Tower
    {

        public NormalTower(Point position)
            : base(position)
        {
            this.range = 500;
            this.rate = 500;
            this.damage = 10;
            this.price = 100;
            this.projectileSpeed = 30;
            this.projectilePicture = "projectile.png";
        }

        public override ImageSource ImageSource
        {
            get{ return ImageFactory.CreateImage("csharp.png"); }
        }

    }
}
