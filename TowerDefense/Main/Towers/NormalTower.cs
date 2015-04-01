namespace TowerDefense.Main.Towers
{
    using System.Windows.Media;
    using TowerDefense.Interfaces;
    using TowerDefense.Utils;

    public class NormalTower : Tower
    {

        public NormalTower(Point position)
            : base(position)
        {
            this.range = 200;
            this.rate = 500;
            this.damage = 10;
            this.price = 100;
            this.projectileSpeed = 30;
            this.projectilePicture = "ball3.png";
        }

        public override ImageSource ImageSource
        {
            get{ return ImageFactory.CreateImage("tower3.png"); }
        }

    }
}
