//Girl Monster - fast monster with low health.
namespace TowerDefense.Main.Monsters
{
    using System;
    using System.Linq;
    using System.Windows.Media;
    using TowerDefense.Interfaces;
    using TowerDefense.Utils;
    
    class MonsterGirl : Monster//, IMonster, IGameObject, IMovable, ITarget - Commented because of team rule.
    {
        public MonsterGirl(IRoute route)
            : base(route, 100, 15, 150)
        {
            this.ImageFIles.Add("monsters/Girl/MonsterGirl0.png");
            this.ImageFIles.Add("monsters/Girl/MonsterGirl1.png");
            this.ImageFIles.Add("monsters/Girl/MonsterGirl2.png");
            this.ImageFIles.Add("monsters/Girl/MonsterGirl3.png");
            this.ImageFIles.Add("monsters/Girl/MonsterGirl4.png");
            this.ImageFIles.Add("monsters/Girl/MonsterGirl5.png");
            this.ImageFIles.Add("monsters/Girl/MonsterGirl6.png");
            this.IsDestroyed = false;
        }
    }
}
