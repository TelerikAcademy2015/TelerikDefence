namespace TowerDefense.Interfaces
{
    using System.Windows.Media.Imaging;

    public interface IDrawable
    {
        int Id
        {
            get;
        }
        Point Position
        {
            get;
        }

        int Depth
        {
            get;
        }

        BitmapSource BitmapSource
        {
            get;
        }

        bool IsDestroyed
        {
            get;
        }
    }
}
