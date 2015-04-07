namespace TowerDefense.Main
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using TowerDefense.Interfaces;

    public class HighscoreProvider : IHighscoreProvider
    {
        public string FilePath
        {
            get;
            private set;
        }

        private List<IPlayer> highscoreEntries;
        public IEnumerable<IPlayer> HighscoreEntries
        {
            get
            {
                return this.highscoreEntries;
            }
        }

        public HighscoreProvider(string filePath)
        {
            this.FilePath = filePath;
            this.InitializeHighscoreEntries();
        }

        public void AddHighscoreEntry(IPlayer player)
        {
            this.highscoreEntries.Add(player);
            this.highscoreEntries = this.highscoreEntries.OrderByDescending(p => p.Score).ToList().Take(GameConstants.HIGHSCORE_MAX_NUMBER_OF_ENTRIES).ToList();
        }

        public void Persist()
        {
            using (StreamWriter writer = new StreamWriter(this.FilePath))
            {
                foreach (IPlayer entry in this.HighscoreEntries)
                {
                    writer.WriteLine("{0, -15}{1, 10}", entry.Name, entry.Score);
                }
            }
        }

        private void InitializeHighscoreEntries()
        {
            this.highscoreEntries = new List<IPlayer>();
            if (!File.Exists(this.FilePath))
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
                        Match match = Regex.Match(line, @"^(\w{3,})\s+(\d+)$");
                        player.Name = match.Groups[1].Value;
                        player.Score = Convert.ToInt32(match.Groups[2].Value);
                        this.highscoreEntries.Add(player);
                    }
                }
            }
            catch (IOException)
            {
                // Ignore errors (leave the highscore empty)
            }
        }
    }
}
