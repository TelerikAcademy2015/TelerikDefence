namespace TowerDefense.Main.Towers
{
    using System;
    using System.Windows.Media.Imaging;
    using TowerDefense.Interfaces;
    using TowerDefense.Main.Towers.Projectiles;
    using TowerDefense.Utils;

    public class MegaTower : Tower
    {

        public override BitmapSource BitmapSource
        {
            get
            {
                return ImageFactory.CreateImage("tower2.png");
            }
        }

        public override int Price
        {
            get
            {
                return 100;
            }
        }

        public override int Range
        {
            get
            {
                return 100;
            }
        }

        public override TimeSpan Rate
        {
            get
            {
                return new TimeSpan(0, 0, 0, 0, 1500);
            }
        }

        public MegaTower(Point center)
            : base(center)
        {
        }

        public override IProjectile CreateProjectile(ITarget target, TimeSpan elapsedTime)
        {
            IProjectile projectile = new MegaTowerProjectile(this.Center, target);
            projectile.Move(elapsedTime);
            return projectile;
        }
    }
}

