namespace TowerDefense.Main
{
    using System;
    using TowerDefense.Interfaces;
    using TowerDefense.Main.Monsters.Waves;

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

        private IPlayer player;
        public IPlayer Player
        {
            get
            {
                if (this.player == null)
                {
                    throw new ArgumentNullException();
                }

                return this.player;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                this.player = value;
            }
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

        private IMonsterWave monsterWave;
        public IMonsterWave MonsterWave
        {
            get
            {
                if (this.monsterWave == null)
                {
                    throw new ArgumentNullException();
                }

                return this.monsterWave;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                this.monsterWave = value;
            }
        }

        private HighscoreProvider highscoreProvider;
        public HighscoreProvider HighscoreProvider
        {
            get
            {
                if (this.highscoreProvider == null)
                {
                    throw new ArgumentNullException();
                }

                return this.highscoreProvider;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                this.highscoreProvider = value;
            }
        }

        private ApplicationContext()
        {
        }
    }
}
