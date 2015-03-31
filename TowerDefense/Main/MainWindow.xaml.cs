using System.Windows;

namespace TowerDefense.Main
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Content = new MainMenu();
        }
    }
}
