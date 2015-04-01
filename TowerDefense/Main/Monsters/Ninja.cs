namespace TowerDefense.Main.Monsters
{
    using System.Windows.Media;
    using TowerDefense.Interfaces;
    using TowerDefense.Utils;

    public class Ninja : Monster
    {
        public Ninja(IRoute route)
            : base(route, 5, 100, 100)
        {
            // Example
            AsyncTimer.DelayedCall(10000, () => this.IsDestroyed = true);
        }

        public override void Update()
        {
        }

        public override ImageSource ImageSource
        {
            get
            {
                // Example
                return ImageFactory.CreateImage("download.png");
            }
        }
    }
}
