using System;
using System.Windows;
using TowerDefense.WPFCustomControls;

namespace TowerDefense.Main
{
    public partial class GameField : PropertyChangedAwaredPage
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
