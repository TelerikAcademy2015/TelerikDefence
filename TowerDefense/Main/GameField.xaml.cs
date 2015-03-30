using System;
using System.ComponentModel;
using System.Windows;
using TowerDefense.Utils;
using TowerDefense.WPFCustomControls;

namespace TowerDefense.Main
{
    public partial class GameField : PropertyChangedAwaredPage
    {
        public Player Player
        {
            get;
            private set;
        }

        public GameField()
        {
            InitializeComponent();
            this.DataContext = this;
            this.Player = ApplicationContext.Instance.Player;

            this.Loaded += (Object sender, RoutedEventArgs e) =>
            {
                Engine engine = new Engine(this.canvas, new Route(this.path));
                ApplicationContext.Instance.Engine = engine;
                engine.Start();
            };
        }
    }
}
