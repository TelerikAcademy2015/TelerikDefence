namespace TowerDefense.Main.Monsters
{
    using TowerDefense.Interfaces;
    using TowerDefense.Utils;

    public class Bird : Monster
    {
        protected override int SpriteColumns
        {
            get
            {
                return 3;
            }
        }

        public Bird(IRoute route) :
            base(route, 50, 300, 5, 100, ImageFactory.CreateImage("bird.png"))
        {
        }
    }
}
