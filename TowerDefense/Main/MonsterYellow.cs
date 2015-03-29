//Monster Yellow - slow monster with high health.
namespace TowerDefense.Main
{
    using System;
    using System.Linq;
    using TowerDefense.Interfaces;
    using System.Windows.Media;
    using TowerDefense.Utils;


    class MonsterYellow : Monster//, IMonster, IGameObject, IMovable, ITarget - Commented because of team rule.
    {
        public MonsterYellow(IRoute route)
            : base(route, 20, 100)
        {
            this.IsDestroyed = false;
            this.ChangeImage();
        }
        public override ImageSource ImageSource
        {
            get
            {
                return ImageFactory.CreateImage("MonsterYellow.png");
            }
        }

        public void ChangeImage()
        {

        }
    }
}
