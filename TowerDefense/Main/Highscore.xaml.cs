namespace TowerDefense.Main
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using TowerDefense.WPFCustomControls;
    public partial class Highscore : PropertyChangedAwaredPage
    {
        public Highscore()
        {
            InitializeComponent();
            this.OpenMainMenuPage = new DelegateCommand((Object parameter) =>
            {
                this.OpenPage(new MainMenu());
            });
            this.DataContext = this;
            PrintHighscore();
        }
        public ICommand OpenMainMenuPage
        {
            get;
            private set;
        }

        private void OpenPage(Page page)
        {
            ((Window)this.Parent).Content = page;
        }

        private void PrintHighscore()
        {
            var highscores = ApplicationContext.Instance.HighscoreProvider.HighscoreEntries;
            foreach (var highscore in highscores)
            {
                this.Content = highscore.Name;
                //PRINT TO PAGE"{0, -15}{1, 10}", entry.Name, entry.Score);
            }
        }
    }
}
