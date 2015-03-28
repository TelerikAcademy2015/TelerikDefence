using System;

namespace TowerDefense.Main
{
    public class Player
    {
        public string Name
        {
            get;
            set;
        }

        public int Score
        {
            get;
            set;
        }

        public int Money
        {
            get;
            set;
        }

        public Player()
        {
            this.Name = String.Empty;
            this.Score = 0;
            this.Money = 200;
        }
    }
}
