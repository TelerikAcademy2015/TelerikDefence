using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TowerDefense.Main
{
    public partial class MainMenu : Page
    {
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

        public MainMenu()
        {
            InitializeComponent();
            this.OpenGameFieldPage = new DelegateCommand((Object parameter) =>
                {
                    this.OpenPage(new GameField());
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
    }
}
