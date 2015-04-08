namespace TowerDefense.Main
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Input;
    using TowerDefense.Interfaces;
    using TowerDefense.WPFCustomControls;

    public partial class Highscore : NavigationPage
    {
        public IEnumerable<IPlayer> HighscoreEntries
        {
            get
            {
                return ApplicationContext.Instance.HighscoreProvider.HighscoreEntries;
            }
        }

        public ICommand OpenMainMenuPage
        {
            get;
            private set;
        }

        public Highscore()
        {
            InitializeComponent();
            this.DataContext = this;
            this.OpenMainMenuPage = new DelegateCommand((Object parameter) =>
            {
                this.NavigateToPage(new MainMenu());
            });
        }
    }
}
