namespace TowerDefense.Main.Monsters
{
    using TowerDefense.Interfaces;
    using TowerDefense.Utils;

    public class Bat : Monster
    {
        protected override int SpriteColumns
        {
            get
            {
                return 3;
            }
        }

        public Bat(IRoute route) :
            base(route, 100, 250, 10, 200, ImageFactory.CreateImage("vampire.png"))
        {
        }
    }
}
