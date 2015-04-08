namespace TowerDefense.Main.Monsters
{
    using TowerDefense.Interfaces;
    using TowerDefense.Utils;

    public class Witch : Monster
    {
        protected override int SpriteColumns
        {
            get
            {
                return 4;
            }
        }

        public Witch(IRoute route) :
            base(route, 100, 250, 10, 200, ImageFactory.CreateImage("witch.png"))
        {
        }
    }
}
