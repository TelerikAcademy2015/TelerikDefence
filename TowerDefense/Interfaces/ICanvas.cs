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

        void UpdateObject(IDrawable drawableObject);

        void AddObject(IDrawable drawableObject);

        void RemoveObject(IDrawable drawableObject);
    }
}
