namespace TowerDefense.Main
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using TowerDefense.Main;
    using TowerDefense.Interfaces;

    public class HighscoreProvider
    {
        public string FilePath
        {
            get;
            private set;
        }

        private List<Player> highscoreEntries;
        public List<Player> HighscoreEntries
        {
            get
            {
                if (this.highscoreEntries != null)
                {
                    return this.highscoreEntries;
                }

                this.highscoreEntries = new List<Player>();
                if(!File.Exists(this.FilePath))
                {
                    File.Create(this.FilePath).Close();                   
                }
                try
                {
                    using (StreamReader reader = new StreamReader(this.FilePath))
                    {
                        string line = null;
                        while ((line = reader.ReadLine()) != null)
                        {
                            Player player = new Player();
                            this.highscoreEntries.Add(player);
                        }
                        return this.highscoreEntries;
                    }
                }
                catch (IOException)
                {
                    return new List<Player>();
                }
            }
            set
            {
                this.highscoreEntries = value;
            }
        }

        public HighscoreProvider(string filePath)
        {
            this.FilePath = filePath;
        }

        public void AddHighscoreEntry(Player player)
        {
            this.HighscoreEntries.Add(player);
            this.HighscoreEntries.Sort((firstPlayer, secondPlayer) => (firstPlayer.Score > secondPlayer.Score) ? -1 : 1);
            this.HighscoreEntries = this.HighscoreEntries.Take(GameConstants.HIGHSCORE_MAX_NUMBER_OF_ENTRIES).ToList();
        }

        public void Persist()
        {
            using (StreamWriter writer = new StreamWriter(this.FilePath))
            {
                foreach (Player entry in this.HighscoreEntries)
                {
                    writer.WriteLine("{0, -15}{1, 10}", entry.Name, entry.Score);
                }
            }
        }
    }
}
