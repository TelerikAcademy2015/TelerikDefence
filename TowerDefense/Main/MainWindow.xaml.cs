namespace TowerDefense.Main
{
    using System;
    using System.Windows;
    using System.Windows.Controls;

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Engine engine = new Engine(this.canvas, new Route(this.path));
            engine.Start();

            InitializeComponent();
            Switcher.pageSwitcher = this;
            //Switcher.Switch(new MainWindow());
        }

        public void Navigate(UserControl nextPage)
        {
            this.Content = nextPage;
        }

        public void Navigate(UserControl nextPage, object state)
        {
            this.Content = nextPage;
            TowerDefense.Interfaces.ISwitchable s = nextPage as TowerDefense.Interfaces.ISwitchable;

            if (s != null)
                s.UtilizeState(state);
            else
                throw new ArgumentException("NextPage is not ISwitchable! "
                  + nextPage.Name.ToString());
        }
    }
}
