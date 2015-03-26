namespace TowerDefense.Main
{
    using System;
    using System.Windows;
    using System.Windows.Controls;

    public partial class GamePlay : UserControl, Interfaces.ISwitchable
    {
        public GamePlay()
        {
            InitializeComponent();
        }

        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }
    }
}
