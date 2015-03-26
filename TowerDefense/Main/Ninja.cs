using System.Windows.Media;
using TowerDefense.Interfaces;
using TowerDefense.Utils;

namespace TowerDefense.Main
{
    public class Ninja : Monster
    {
        public Ninja(Point position)
            : base(position)
        {
            // Example
            AsyncTimer.DelayedCall(5000, () =>
            {
                this.Position = new Point(this.Position.X + 100, this.Position.Y + 100);
            });
        }

        public override void Update()
        {
            // Example
            this.Position = new Point(this.Position.X + 1, this.Position.Y + 1);
        }

        public override ImageSource ImageSource
        {
            get
            {
                // Example                
                return ImageFactory.CreateImage("download.jpg");
            }
        }
    }
}
