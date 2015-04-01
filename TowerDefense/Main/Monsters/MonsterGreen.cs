namespace TowerDefense.Main.Monsters
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Windows.Media;
    using TowerDefense.Interfaces;
    using TowerDefense.Utils;

    public class MonsterGreen : Monster
    {
        //For example: goldValue = 10;
        //if(this.IsDestroyed)
        //{
        //  gold += goldvalue;
        //}
        public MonsterGreen(IRoute route)
            : base(route, 20, 10, 100)
        {
            this.IsDestroyed = false;
        }

        public override ImageSource ImageSource
        {
            get
            {
                return ImageFactory.CreateImage("MonsterGreen.png");
            }
        }
    }
}
