//Monster Sweety - average speed monster with with average helth.
namespace TowerDefense.Main
{
    using System;
    using System.Linq;
    using TowerDefense.Interfaces;
    using System.Windows.Media;
    using TowerDefense.Utils;


    class MonsterSweety : Monster//, IMonster, IGameObject, IMovable, ITarget - Commented because of team rule.
    {
        public MonsterSweety(IRoute route)
            : base(route, 60, 25, 100)
        {
            this.IsDestroyed = false;
            this.ChangeImage();
        }
        public override ImageSource ImageSource
        {
            get
            {
                return ImageFactory.CreateImage("MonsterSweety.png");
            }
        }

        public void ChangeImage()
        {

        }
    }
}
