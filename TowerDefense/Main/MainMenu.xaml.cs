using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TowerDefense.Interfaces;
using TowerDefense.WPFCustomControls;

namespace TowerDefense.Main
{
    public partial class MainMenu : PropertyChangedAwaredPage, IValidatable
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

        public Player Player
        {
            get;
            private set;
        }

        public MainMenu()
        {
            InitializeComponent();
            this.Player = ApplicationContext.Instance.Player;
            this.OpenGameFieldPage = new DelegateCommand((Object parameter) =>
                {
                    if (this.IsValid())
                    {
                        this.OpenPage(new GameField());
                    }
                });
            this.OpenHighscorePage = new DelegateCommand((Object parameter) =>
            {
                this.OpenPage(new Highscore());
            });
            this.DataContext = this;
        }

        private void OpenPage(Page page)
        {
            ((Window)this.Parent).Content = page;
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
            if (String.IsNullOrWhiteSpace(this.Player.Name))
            {
                this.ErrorMessage = INVALID_USERNAME_ERROR_MESSAGE;
                return false;
            }
            this.ErrorMessage = String.Empty;
            return true;
        }
    }
}
