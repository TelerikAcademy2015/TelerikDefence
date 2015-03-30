using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerDefense.Interfaces;
using TowerDefense.Utils;
using System.Windows.Media;

namespace TowerDefense.Main
{
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
