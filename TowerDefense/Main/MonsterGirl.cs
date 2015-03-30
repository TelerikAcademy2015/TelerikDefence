//Girl Monster - fast monster with low health.
namespace TowerDefense.Main
{
    using System;
    using System.Linq;
    using TowerDefense.Interfaces;
    using System.Windows.Media;
    using TowerDefense.Utils;


    class MonsterGirl : Monster//, IMonster, IGameObject, IMovable, ITarget - Commented because of team rule.
    {
        public MonsterGirl(IRoute route)
            : base(route, 100, 10, 100)
        {
            this.IsDestroyed = false;
            this.ChangeImage();
        }
        public override ImageSource ImageSource
        {
            get
            {
                return ImageFactory.CreateImage("MonsterGirl.png");
            }
        }

        public void ChangeImage()
        {

        }
    }
}
