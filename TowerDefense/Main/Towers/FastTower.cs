namespace TowerDefense.Main.Towers
{
    using System;
    using System.Windows.Media.Imaging;
    using TowerDefense.Interfaces;
    using TowerDefense.Main.Towers.Projectiles;
    using TowerDefense.Utils;

    public class FastTower : Tower
    {

        public override BitmapSource BitmapSource
        {
            get
            {
                return ImageFactory.CreateImage("tower4.png");
            }
        }

        public override int Price
        {
            get
            {
                return 200;
            }
        }

        public override int Range
        {
            get
            {
                //for testing purposes, otherwise 250
                return 800;
            }
        }

        public override TimeSpan Rate
        {
            get
            {
                //for testing purposes, otherwise 500
                return new TimeSpan(0, 0, 0, 0, 1500);
            }
        }

        public FastTower(Point center)
            : base(center)
        {
        }

        public override IProjectile CreateProjectile(ITarget target, TimeSpan elapsedTime)
        {
            IProjectile projectile = new FastTowerProjectile(this.Center, target);
            projectile.Move(elapsedTime);
            return projectile;
        }
    }
}

