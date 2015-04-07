﻿namespace TowerDefense.Main.Commands
{
    using System;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Input;
    using TowerDefense.Interfaces;
    using TowerDefense.WPFCustomControls;

    public class PlaceTowerCommand : ICommand
    {
        private Type towerType;
        private MouseButtonEventHandler action;

        public PlaceTowerCommand()
        {
            this.action = (object sender, MouseButtonEventArgs e) =>
            {
                Application.Current.MainWindow.MouseUp -= action;
                if (e.Source is WPFCanvas)
                {
                    WPFCanvas canvas = e.Source as WPFCanvas;
                    System.Windows.Point clickedPosition = e.GetPosition(canvas);
                    var towerConstructor = towerType.GetConstructor(new Type[] { typeof(Interfaces.Point) });
                    ITower tower = (ITower)towerConstructor.Invoke(new object[] { new Interfaces.Point(clickedPosition.X, clickedPosition.Y) });
                    if (!ApplicationContext.Instance.Engine.TryAddTower(tower))
                    {
                        Application.Current.MainWindow.MouseUp += action;
                    }
                }
            };
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            this.towerType = parameter as Type;
            Application.Current.MainWindow.MouseUp += action;
        }
    }
}
