namespace TowerDefense.Main
{
    using System;
    using System.Windows.Controls;

    public partial class GameScore : UserControl, Interfaces.ISwitchable
    {
        public GameScore()
        {
            InitializeComponent();
        }

        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }
    }
}
