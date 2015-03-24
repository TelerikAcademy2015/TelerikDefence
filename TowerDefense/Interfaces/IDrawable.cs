using System.Windows.Media;

namespace TowerDefense.Interfaces
{
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

        ImageSource ImageSource
        {
            get;
        }
    }
}
