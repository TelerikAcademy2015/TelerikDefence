namespace TowerDefense.Main.Towers
{
    using System.Windows.Media;
    using TowerDefense.Interfaces;
    using TowerDefense.Utils;

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
            this.projectilePicture = "ball1.png";
        }

        public override ImageSource ImageSource
        {
            get { return ImageFactory.CreateImage("tower1.png"); }
        }

    }
}

