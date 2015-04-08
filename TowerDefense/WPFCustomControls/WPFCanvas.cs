namespace TowerDefense.WPFCustomControls
{
    using System.Collections.Generic;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Shapes;
    using TowerDefense.Interfaces;

    public class WPFCanvas : Canvas, ICanvas
    {
        private IDictionary<IDrawable, Rectangle> gameToUIObjects;

        public WPFCanvas()
        {
            this.gameToUIObjects = new SortedDictionary<IDrawable, Rectangle>(Comparer<IDrawable>.Create((x, y) =>
                {
                    if (x.Depth.CompareTo(y.Depth) == 0)
                    {
                        return x.Id.CompareTo(y.Id);
                    }

                    return x.Depth.CompareTo(y.Depth);
                }));
        }

        public void UpdateObject(IDrawable drawableObject)
        {
            Rectangle rectangle = this.gameToUIObjects[drawableObject];
            rectangle.Width = drawableObject.BitmapSource.Width;
            rectangle.Height = drawableObject.BitmapSource.Height;
            rectangle.Fill = new ImageBrush(drawableObject.BitmapSource);
            Canvas.SetLeft(rectangle, drawableObject.Position.X);
            Canvas.SetTop(rectangle, drawableObject.Position.Y);
        }

        public void AddObject(IDrawable drawableObject)
        {
            Rectangle rectangle = new Rectangle();
            this.Children.Add(rectangle);
            this.gameToUIObjects.Add(drawableObject, rectangle);
        }

        public void RemoveObject(IDrawable drawableObject)
        {
            if (this.gameToUIObjects.ContainsKey(drawableObject))
            {
                this.Children.Remove(gameToUIObjects[drawableObject]);
                this.gameToUIObjects.Remove(drawableObject);
            }
        }
    }
}