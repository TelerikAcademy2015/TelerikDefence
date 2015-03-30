using System;
namespace TowerDefense.Main
{
    public class ApplicationContext
    {
        private string HIGHSCORE_FILE_NAME = "highscore.txt";
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

        private Engine engine;
        public Engine Engine
        {
            get
            {
                if (this.engine == null)
                {
                    throw new ArgumentNullException();
                }

                return this.engine;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                this.engine = value;
            }
        }

        public HighscoreProvider HighscoreProvider
        {
            get;
            private set;
        }

        private ApplicationContext()
        {
            this.Player = new Player();
            this.HighscoreProvider = new HighscoreProvider(HIGHSCORE_FILE_NAME);
        }
    }
}
