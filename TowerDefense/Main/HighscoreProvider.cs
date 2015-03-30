using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TowerDefense.Main;

namespace TowerDefense.Main
{
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
            // TODO :
            get
            {
                throw new NotImplementedException();
            }
            private set
            {
                throw new NotImplementedException();
            }
        }

        public HighscoreProvider(string filePath)
        {
            this.FilePath = filePath;
        }

        public void AddHighscoreEntry(Player player)
        {

        }

        public void Persist()
        {
            // Format:
            // 1. Dragan Ivanov                 670
            // 2. Lelq mu                       630
            // <----------20----------><----10---->
        }
    }
}
