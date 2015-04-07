namespace TowerDefense.Main.Monsters
{
    using TowerDefense.Interfaces;
    using TowerDefense.Utils;

    public class Deamon : Monster
    {
        protected override int SpriteColumns
        {
            get
            {
                return 3;
            }
        }

        public Deamon(IRoute route) :
            base(route, 50, 300, 5, 100, ImageFactory.CreateImage("deamon.png"))
        {
        }
    }
}
