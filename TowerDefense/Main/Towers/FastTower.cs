namespace TowerDefense.Main.Towers
{
    using System.Windows.Media;
    using TowerDefense.Interfaces;
    using TowerDefense.Utils;

    public class FastTower : Tower
    {

        public FastTower(Point position)
            : base(position)
        {
            this.range = 300;
            this.rate = 300;
            this.damage = 4;
            this.price = 130;
            this.projectileSpeed = 40;
            this.projectilePicture = "ball4.png";
        }

        public override ImageSource ImageSource
        {
            get { return ImageFactory.CreateImage("tower4.png"); }
        }

    }
}

