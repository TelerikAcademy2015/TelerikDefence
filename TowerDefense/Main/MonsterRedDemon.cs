namespace TowerDefense.Main
{
    using System;
    using System.Linq;
    using TowerDefense.Interfaces;
    using System.Windows.Media;
    using TowerDefense.Utils;


    class MonsterRedDemon : Monster//, IMonster, IGameObject, IMovable, ITarget - Commented because of team rule.
    {
        public MonsterRedDemon(IRoute route)
            : base(route, 30, 300, 400)
        {
            this.ImageFIles.Add("monsters/RedDemon/MonsterRedDemon0.png");
            this.ImageFIles.Add("monsters/RedDemon/MonsterRedDemon1.png");
            this.ImageFIles.Add("monsters/RedDemon/MonsterRedDemon2.png");
            this.ImageFIles.Add("monsters/RedDemon/MonsterRedDemon3.png");
            this.ImageFIles.Add("monsters/RedDemon/MonsterRedDemon4.png");
            this.ImageFIles.Add("monsters/RedDemon/MonsterRedDemon5.png");
            this.ImageFIles.Add("monsters/RedDemon/MonsterRedDemon6.png");
            this.ImageFIles.Add("monsters/RedDemon/MonsterRedDemon7.png");
            this.ImageFIles.Add("monsters/RedDemon/MonsterRedDemon8.png");
            this.ImageFIles.Add("monsters/RedDemon/MonsterRedDemon9.png");
            this.ImageFIles.Add("monsters/RedDemon/MonsterRedDemon10.png");
            this.IsDestroyed = false;
        }
    }
}
