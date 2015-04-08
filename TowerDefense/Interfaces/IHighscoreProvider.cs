namespace TowerDefense.Interfaces
{
    using System.Collections.Generic;

    public interface IHighscoreProvider
    {
        IEnumerable<IPlayer> HighscoreEntries
        {
            get;
        }

        void AddHighscoreEntry(IPlayer player);

        void Persist();
    }
}
