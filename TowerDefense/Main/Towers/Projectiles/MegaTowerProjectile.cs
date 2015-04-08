namespace TowerDefense.Main.Towers.Projectiles
{
    using System.Windows.Media.Imaging;
    using TowerDefense.Interfaces;
    using TowerDefense.Utils;

    public class MegaTowerProjectile : Projectile
    {
        public override BitmapSource BitmapSource
        {
            get
            {
                return ImageFactory.CreateImage("ball3.png");
            }
        }

        public override int Speed
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
                return 50;
            }
        }

        public MegaTowerProjectile(Point center, ITarget target)
            : base(center, target)
        {
        }
    }
}
