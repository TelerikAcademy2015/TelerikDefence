namespace TowerDefense.Interfaces
{
    public interface ICanvas
    {
        double Width
        {
            get;
        }

        double Height
        {
            get;
        }

        void AddObject(IDrawable drawableObject);

        void RemoveObject(IDrawable drawableObject);

        void UpdateObject(IDrawable drawableObject);
    }
}
