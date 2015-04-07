namespace TowerDefense.Interfaces
{
    using System.ComponentModel;

    public interface IPlayer : INotifyPropertyChanged
    {
        string Name
        {
            get;
            set;
        }

        int Score
        {
            get;
            set;
        }

        int Money
        {
            get;
            set;
        }

        int Lives
        {
            get;
            set;
        }
    }
}
