
using System.Collections.Generic;

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

        private void PrintHighscore()
        {
            var highscores = ApplicationContext.Instance.HighscoreProvider.HighscoreEntries;
        }

        private void PrintResults()
        {
            var results = GetResults();

            var i = 0;

            foreach (var result in results)
            {
                TextBlock HelloWorldTextBlock = new TextBlock();
                HelloWorldTextBlock.FontSize = 24;

                HelloWorldTextBlock.Text = "[" + (i + 1) + "]" + result.Key + ": " + result.Value;

                LayoutGrid.Children.Add(HelloWorldTextBlock);
                Grid.SetRow(HelloWorldTextBlock, i++);
                Grid.SetColumn(HelloWorldTextBlock, 2);
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
