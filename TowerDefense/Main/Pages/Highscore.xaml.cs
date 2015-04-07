
using System.Collections.Generic;
using System.Windows.Documents;

namespace TowerDefense.Main
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;

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

            this.PrintResults();
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

        private List<Player> GetHighscore()
        {
            var highscores = ApplicationContext.Instance.HighscoreProvider.HighscoreEntries;

            return highscores;
        }

        private void PrintResults()
        {
            var results = GetHighscore();

            if (results.Count > 0)
            {
                var i = 0;
                foreach (var result in results)
                {
                    TextBlock HelloWorldTextBlock = new TextBlock();
                    HelloWorldTextBlock.FontSize = 24;
                    HelloWorldTextBlock.Text = "[" + (i + 1) + "]" + result.Name + ": " + result.Score;
                    HelloWorldTextBlock.FontFamily = new FontFamily("Segoe UI Mono");
                        
                    LayoutGrid.Children.Add(HelloWorldTextBlock);
                    LayoutGrid.VerticalAlignment = VerticalAlignment.Center;
                    LayoutGrid.HorizontalAlignment = HorizontalAlignment.Center;
                    Grid.SetRow(HelloWorldTextBlock, i++);
                    Grid.SetColumn(HelloWorldTextBlock, 2);
                }
            }
            else
            {
                TextBlock HelloWorldTextBlock = new TextBlock();
                HelloWorldTextBlock.FontSize = 24;

                HelloWorldTextBlock.Text = "[no results]";

                LayoutGrid.Children.Add(HelloWorldTextBlock);
                Grid.SetRow(HelloWorldTextBlock, 1);
                Grid.SetColumn(HelloWorldTextBlock, 1);
            }
        }

        private Dictionary<string, int> GetResults()
        {
            var results = new Dictionary<string, int>();

            results.Add("Pesho", 100);
            results.Add("Gosho", 200);
            results.Add("Tosho", 300);

            return results;
        }
    }
}
