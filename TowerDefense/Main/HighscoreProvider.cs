namespace TowerDefense.Main
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using TowerDefense.Main;

    public class HighscoreProvider
    {
        private const int MAX_NUMBER_OF_ENTRIES = 5;

        public string FilePath
        {
            get;
            private set;
        }

        private List<Player> highscoreEntries;
        public IEnumerable<Player> HighscoreEntries
        {
            get
            {
                return this.highscoreEntries;
            }
            private set
            {
                if (value.Count() >= MAX_NUMBER_OF_ENTRIES)
                {
                    //throw new ArgumentOutOfRangeException("Too much entries");
                }
                this.highscoreEntries.AddRange(value);
            }
        }

        public HighscoreProvider(string filePath)
        {
            this.FilePath = filePath;
            this.highscoreEntries = new List<Player>();
        }

        public void AddHighscoreEntry(Player player)
        {
            this.highscoreEntries.Add(player);
        }

        public void Persist()
        {
            var writer = new StreamWriter(this.FilePath, false);
            using (writer)
            {
                int counter = 1;
                foreach (var highscore in this.HighscoreEntries)
                {
                    writer.WriteLine(string.Format("{0}. {1,17}{2,-10}", counter, highscore.Name, highscore.Score));
                    counter++;
                }
                counter = 1;
            }
            // Format:
            // 1. Dragan Ivanov                 670
            // 2. Lelq mu                       630
            // <----------20----------><----10---->
        }
    }
}
