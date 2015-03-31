using System.Windows.Media;
using TowerDefense.Interfaces;
using TowerDefense.Utils;

namespace TowerDefense.Main
{
    public class SlowTower : Tower
    {

        public SlowTower(Point position)
            : base(position)
        {
            this.range = 250;
            this.rate = 1500;
            this.damage = 60;
            this.price = 200;
            this.projectileSpeed = 15;
            this.projectilePicture = "projectile.png";
        }

        public override ImageSource ImageSource
        {
            get { return ImageFactory.CreateImage("dotnet.png"); }
        }

    }
}

