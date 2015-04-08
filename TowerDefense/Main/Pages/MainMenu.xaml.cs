namespace TowerDefense.Main
{
    using System;
    using System.Text.RegularExpressions;
    using System.Windows.Input;
    using TowerDefense.Interfaces;
    using TowerDefense.WPFCustomControls;

    public partial class MainMenu : NavigationPage, IValidatable
    {
        public const string INVALID_USERNAME_ERROR_MESSAGE = "Invalid username!";

        public ICommand OpenGameFieldPage
        {
            get;
            private set;
        }

        public ICommand OpenHighscorePage
        {
            get;
            private set;
        }

        public IPlayer Player
        {
            get
            {
                return ApplicationContext.Instance.Player;
            }
        }

        public MainMenu()
        {
            InitializeComponent();

            ApplicationContext.Instance.Player = new Player();
            ApplicationContext.Instance.HighscoreProvider = new HighscoreProvider(GameConstants.HIGHSCORE_FILE_NAME);

            this.OpenGameFieldPage = new DelegateCommand((Object parameter) =>
                {
                    if (this.IsValid())
                    {
                        this.NavigateToPage(new GameField());
                    }
                });

            this.OpenHighscorePage = new DelegateCommand((Object parameter) =>
            {
                this.NavigateToPage(new Highscore());
            });

            this.DataContext = this;
        }

        private string errorMessage;
        public string ErrorMessage
        {
            get
            {
                return this.errorMessage;
            }
            set
            {
                this.errorMessage = value;
                this.OnPropertyChanged("ErrorMessage");
            }
        }

        public bool IsValid()
        {

            if (!Regex.IsMatch(this.Player.Name, @"^\w{3,}$"))
            {
                this.ErrorMessage = INVALID_USERNAME_ERROR_MESSAGE;
                return false;
            }
            this.ErrorMessage = String.Empty;
            return true;
        }
    }
}
