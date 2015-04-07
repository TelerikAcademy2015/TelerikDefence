namespace TowerDefense.Main
{
    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Input;
    using TowerDefense.Interfaces;
    using TowerDefense.Main.Commands;
    using TowerDefense.Main.Monsters.Waves;
    using TowerDefense.Utils;
    using TowerDefense.WPFCustomControls;

    public partial class GameField : NavigationPage
    {
        public ICommand PlaceTowerCommand
        {
            get;
            private set;
        }

        public ICommand StartCommand
        {
            get;
            private set;
        }

        public ICommand StopCommand
        {
            get;
            private set;
        }

        public ICommand GameOverOKCommand
        {
            get;
            private set;
        }

        public IPlayer Player
        {
            get
            {
                return ApplicationContext.Instance.Player;
            }
        }

        public IMonsterWave MonsterWave
        {
            get
            {
                return ApplicationContext.Instance.MonsterWave;
            }
        }

        private bool isGameOver;
        public bool IsGameOver
        {
            get
            {
                return this.isGameOver;
            }
            private set
            {
                this.isGameOver = value;
                this.OnPropertyChanged("IsGameOver");
            }
        }

        public GameField()
        {
            InitializeComponent();
            this.PlaceTowerCommand = new PlaceTowerCommand();
            this.StartCommand = new DelegateCommand((Object parameter) => ApplicationContext.Instance.Engine.Start());
            this.StopCommand = new DelegateCommand((Object parameter) => ApplicationContext.Instance.Engine.Stop());
            this.GameOverOKCommand = new DelegateCommand((Object parameter) => this.NavigateToPage(new MainMenu()));
            this.IsGameOver = false;

            this.Player.PropertyChanged += (Object sender, PropertyChangedEventArgs e) =>
                {
                    if (e.PropertyName != "Lives")
                    {
                        return;
                    }

                    IPlayer player = (IPlayer)sender;
                    if (player.Lives == 0)
                    {
                        this.IsGameOver = true;
                    }
                };

            this.Loaded += (Object sender, RoutedEventArgs e) =>
            {
                this.DataContext = this;
                var margin = this.path.Margin;
                this.path.Margin = new Thickness((this.canvas.ActualWidth - this.path.Width) / 2, margin.Top, margin.Right, margin.Bottom);
                IRoute route = new Route(this.path);
                Engine engine = new Engine(this.canvas, route);
                ApplicationContext.Instance.Engine = engine;
                engine.Start();
            };
        }
    }
}
