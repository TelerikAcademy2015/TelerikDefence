namespace TowerDefense.Main
{
    using System;
    using System.Windows;
    using System.Windows.Controls;

    public partial class GameStart : UserControl, Interfaces.ISwitchable
    {
        public GameStart()
        {
            InitializeComponent();
        }

        public void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new GamePlay());
        }

        private void ScoreButton_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new GameScore());
        }

        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }
    }
}
