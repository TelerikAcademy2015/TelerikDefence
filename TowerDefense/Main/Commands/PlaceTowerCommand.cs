using System;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using TowerDefense.Interfaces;
using TowerDefense.WPFCustomControls;

namespace TowerDefense.Main.Commands
{
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
                    ITower tower = this.CreateTowerByCenter(towerConstructor, new Interfaces.Point(clickedPosition.X, clickedPosition.Y));
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

        private ITower CreateTowerByCenter(ConstructorInfo constructor, Interfaces.Point center)
        {
            ITower tower = this.CreateTowerByPoint(constructor, new Interfaces.Point(0, 0));
            Interfaces.Point topLeft = center - tower.Center;
            return this.CreateTowerByPoint(constructor, topLeft);
        }

        private ITower CreateTowerByPoint(ConstructorInfo constructor, Interfaces.Point point)
        {
            return (ITower)constructor.Invoke(new object[] { point });
        }
    }
}
