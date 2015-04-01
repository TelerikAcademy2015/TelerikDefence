namespace TowerDefense.WPFCustomControls
{
    using System.ComponentModel;
    using System.Windows.Controls;

    public class PropertyChangedAwaredPage : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
