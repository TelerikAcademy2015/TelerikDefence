namespace TowerDefense.Main.Towers.Projectiles
{
    using System.Windows.Media.Imaging;
    using TowerDefense.Interfaces;
    using TowerDefense.Utils;

    public class FastTowerProjectile : Projectile
    {
        public override BitmapSource BitmapSource
        {
            get
            {
                return ImageFactory.CreateImage("ball4.png");
            }
        }

        public override int Speed
        {
            get
            {
                return 2000;
            }
        }

        public override int Damage
        {
            get
            {
                return 50;
            }
        }

        public FastTowerProjectile(Point center, ITarget target)
            : base(center, target)
        {
        }
    }
}
