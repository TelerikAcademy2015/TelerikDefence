namespace TowerDefense.Main
{
    public class ApplicationContext
    {
        private static ApplicationContext instance = new ApplicationContext();
        public static ApplicationContext Instance
        {
            get
            {
                return instance;
            }
        }

        public Player Player
        {
            get;
            private set;
        }

        private ApplicationContext()
        {
            this.Player = new Player();
        }
    }
}
