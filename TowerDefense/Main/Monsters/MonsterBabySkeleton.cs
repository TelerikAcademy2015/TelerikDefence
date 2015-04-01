namespace TowerDefense.Main.Monsters
{
    using System;
    using System.Linq;
    using System.Windows.Media;
    using TowerDefense.Utils;
    using TowerDefense.Interfaces;
    
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