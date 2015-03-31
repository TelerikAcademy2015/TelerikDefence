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
    }
}
