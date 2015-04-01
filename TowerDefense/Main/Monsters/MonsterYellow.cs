//Monster Yellow - slow monster with high health.
namespace TowerDefense.Main.Monsters
{
    using System;
    using System.Linq;
    using TowerDefense.Interfaces;
    using System.Windows.Media;
    using TowerDefense.Utils;

    class MonsterYellow : Monster//, IMonster, IGameObject, IMovable, ITarget - Commented because of team rule.
    {
        public MonsterYellow(IRoute route)
            : base(route, 15, 100, 100)
        {
            this.ImageFIles.Add("monsters/Yellow/MonsterYellow0.png");
            this.ImageFIles.Add("monsters/Yellow/MonsterYellow1.png");
            this.ImageFIles.Add("monsters/Yellow/MonsterYellow2.png");
            this.ImageFIles.Add("monsters/Yellow/MonsterYellow3.png");
            this.ImageFIles.Add("monsters/Yellow/MonsterYellow1.png");
            this.IsDestroyed = false;
        }
    }
}