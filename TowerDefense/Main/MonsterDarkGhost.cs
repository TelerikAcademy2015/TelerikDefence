namespace TowerDefense.Main
{
    using System;
    using System.Linq;
    using TowerDefense.Interfaces;
    using System.Windows.Media;
    using TowerDefense.Utils;


    class MonsterDarkGhost : Monster//, IMonster, IGameObject, IMovable, ITarget - Commented because of team rule.
    {
        public MonsterDarkGhost(IRoute route)
            : base(route, 90, 150, 225)
        {
            this.ImageFIles.Add("monsters/DarkGhost/MonsterDarkGhost0.png");
            this.ImageFIles.Add("monsters/DarkGhost/MonsterDarkGhost1.png");
            this.ImageFIles.Add("monsters/DarkGhost/MonsterDarkGhost2.png");
            this.IsDestroyed = false;
        }
    }
}