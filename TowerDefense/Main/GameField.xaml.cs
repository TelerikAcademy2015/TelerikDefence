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
                ApplicationContext.Instance.Engine = engine;
                var player = new Player();
                player.Score = 5;
                player.Name = "fgdfgd";
                ApplicationContext.Instance.HighscoreProvider.AddHighscoreEntry(player);
                var player1 = new Player();
                player1.Name = "gdg";
                player1.Score = 54543;
                ApplicationContext.Instance.HighscoreProvider.AddHighscoreEntry(player1);
                ApplicationContext.Instance.HighscoreProvider.Persist();
                engine.Start();
            };
        }
    }
}
