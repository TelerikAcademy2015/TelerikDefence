using System.Windows.Media;
using TowerDefense.Interfaces;
using TowerDefense.Utils;

namespace TowerDefense.Main
{
    public class Ninja : Monster
    {
        public Ninja(IRoute route)
            : base(route, 5, 100)
        {
            // Example
            AsyncTimer.DelayedCall(5000, () => this.IsDestroyed = true);
        }

        public override void Update()
        {
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
