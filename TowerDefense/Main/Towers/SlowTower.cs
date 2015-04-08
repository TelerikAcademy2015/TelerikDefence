namespace TowerDefense.Main.Towers
{
    using System;
    using System.Windows.Media.Imaging;
    using TowerDefense.Interfaces;
    using TowerDefense.Main.Towers.Projectiles;
    using TowerDefense.Utils;

    public class SlowTower : Tower
    {
        public override BitmapSource BitmapSource
        {
            get
            {
                return ImageFactory.CreateImage("tower1.png");
            }
        }

        public override int Price
        {
            get
            {
                return 300;
            }
        }

        public override int Range
        {
            get
            {
                return 400;
            }
        }

        public override TimeSpan Rate
        {
            get
            {
                return new TimeSpan(0, 0, 0, 0, 2000);
            }
        }

        public SlowTower(Point center)
            : base(center)
        {
        }

        public override IProjectile CreateProjectile(ITarget target, TimeSpan elapsedTime)
        {
            IProjectile projectile = new SlowTowerProjectile(this.Center, target);
            projectile.Move(elapsedTime);
            return projectile;
        }
    }
}

