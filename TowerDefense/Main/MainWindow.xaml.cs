using System.Windows;

namespace TowerDefense.Main
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Engine engine = new Engine(this.canvas, new Route(this.path));
            engine.Start();
        }
    }
}
