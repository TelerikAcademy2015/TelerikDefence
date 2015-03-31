namespace TowerDefense.Main
{
    using System;
    using System.Linq;
    using TowerDefense.Interfaces;
    using System.Windows.Media;
    using TowerDefense.Utils;


    class MonsterBabySkeleton : Monster//, IMonster, IGameObject, IMovable, ITarget - Commented because of team rule.
    {
        public MonsterBabySkeleton(IRoute route)
            : base(route, 70, 20, 150)
        {
            this.ImageFIles.Add("monsters/BabySkeleton/MonsterBabySkeleton0.png");
            this.ImageFIles.Add("monsters/BabySkeleton/MonsterBabySkeleton1.png");
            this.ImageFIles.Add("monsters/BabySkeleton/MonsterBabySkeleton2.png");
            this.IsDestroyed = false;
        }
    }
}