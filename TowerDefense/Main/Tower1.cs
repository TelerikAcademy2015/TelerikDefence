using System;
using System.Collections.Generic;
using System.Timers;
using System.Windows.Media;
using TowerDefense.Interfaces;
using TowerDefense.Utils;

namespace TowerDefense.Main
{
    public class Tower1 : Tower
    {
        
        public Tower1(Point position)
            : base(position)
        {
            this.range = 40000;
            this.rate = 1000;
            this.damage = 10;
            this.price = 100;
        }

        public override ImageSource ImageSource
        {
            get
            {                
                return ImageFactory.CreateImage("cpp.png");
            }
        }

        public override void Update()
        {
            foreach (var projectile in projectiles)
            {
                projectile.Update();
                projectile.Move();
            }           
        }

        public override void Shoot(ICollection<ITarget> targetsSet)
        {
            base.Shoot(targetsSet);
            if ( this.Target != null)
            {
                Projectile projectile = new Projectile(new Point(this.Position.X, this.Position.Y),
                                                        this.Damage,
                                                        10,
                                                        this.Target);
                //for testing purposes only 1 bullet
                if (projectiles.Count < 1)
                {
                    projectiles.Add(projectile);
                }
            }
        }
    }
}
