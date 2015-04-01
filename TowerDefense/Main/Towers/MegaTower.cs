namespace TowerDefense.Main.Towers
{
    using System.Windows.Media;
    using TowerDefense.Interfaces;
    using TowerDefense.Utils;

    public class MegaTower : Tower
    {

        public MegaTower(Point position)
            : base(position)
        {
            this.range = 500;
            this.rate = 600;
            this.damage = 35;
            this.price = 350;
            this.projectileSpeed = 25;
            this.projectilePicture = "ball2.png";
        }

        public override ImageSource ImageSource
        {
            get { return ImageFactory.CreateImage("tower2.png"); }
        }

    }
}

