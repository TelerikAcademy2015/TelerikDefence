namespace TowerDefense.Main
{
    using System;
    using TowerDefense.Interfaces;

    public class Player : PropertyChangedAwaredObject, IPlayer
    {
        private string name;

        public string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
            }
        }

        private int score;
        public int Score
        {
            get
            {
                return this.score;
            }
            set
            {
                this.score = value;
                this.OnPropertyChanged("Score");
            }
        }

        private int money;
        public int Money
        {
            get
            {
                return this.money;
            }
            set
            {
                this.money = value;
                this.OnPropertyChanged("Money");
            }
        }

        private int lives;
        public int Lives
        {
            get
            {
                return this.lives;
            }
            set
            {
                this.lives = value;
                this.OnPropertyChanged("Lives");
            }
        }

        public Player()
        {
            this.Name = String.Empty;
            this.Score = 0;
            this.Money = 20000;
            this.Lives = 10;
        }
    }
}
