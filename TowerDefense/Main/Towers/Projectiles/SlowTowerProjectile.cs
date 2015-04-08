﻿namespace TowerDefense.Main.Towers.Projectiles
{
    using System.Windows.Media.Imaging;
    using TowerDefense.Interfaces;
    using TowerDefense.Utils;

    public class SlowTowerProjectile : Projectile
    {
        public override BitmapSource BitmapSource
        {
            get
            {
                return ImageFactory.CreateImage("ball1.png");
            }
        }

        public override int Speed
        {
            get
            {
                return 400;
            }
        }

        public override int Damage
        {
            get
            {
                return 150;
            }
        }

        public SlowTowerProjectile(Point center, ITarget target)
            : base(center, target)
        {
        }
    }
}
