using System;
using System.Windows;
using System.Windows.Controls;

namespace TowerDefense.Main
{
    public partial class GameField : Page
    {
        public GameField()
        {
            this.Loaded += (Object sender, RoutedEventArgs e) =>
            {
                InitializeComponent();
                Engine engine = new Engine(this.canvas, new Route(this.path));
                engine.Start();
            };
        }
    }
}
