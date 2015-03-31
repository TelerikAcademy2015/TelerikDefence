//Monster Sweety - average speed monster with with average helth.
namespace TowerDefense.Main
{
    using System;
    using System.Linq;
    using TowerDefense.Interfaces;
    using System.Windows.Media;
    using TowerDefense.Utils;
    using System.Collections.Generic;


    class MonsterSweety : Monster//, IMonster, IGameObject, IMovable, ITarget - Commented because of team rule.
    {
        public MonsterSweety(IRoute route)
            : base(route, 60, 25, 200)
        {
            this.ImageFIles.Add("monsters/Sweety/MonsterSweety0.png");
            this.ImageFIles.Add("monsters/Sweety/MonsterSweety1.png");
            this.ImageFIles.Add("monsters/Sweety/MonsterSweety2.png");
            this.ImageFIles.Add("monsters/Sweety/MonsterSweety1.png");
            this.IsDestroyed = false;
        }
    }
}
