using System.Windows.Media;
using TowerDefense.Interfaces;
using TowerDefense.Utils;

namespace TowerDefense.Main
{
    public class FastTower : Tower
    {

        public FastTower(Point position)
            : base(position)
        {
            this.range = 1000;
            this.rate = 300;
            this.damage = 4;
            this.price = 130;
            this.projectileSpeed = 40;
            this.projectilePicture = "projectile.png";
        }

        public override ImageSource ImageSource
        {
            get { return ImageFactory.CreateImage("cpp.png"); }
        }

    }
}

