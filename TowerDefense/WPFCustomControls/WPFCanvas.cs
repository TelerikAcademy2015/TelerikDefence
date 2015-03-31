using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using TowerDefense.Interfaces;

namespace TowerDefense.WPFCustomControls
{
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
            if (!this.gameToUIObjects.ContainsKey(drawableObject))
            {
                this.AddObject(drawableObject);
            }

            if (drawableObject.IsDestroyed)
            {
                this.RemoveObject(drawableObject);
                return;
            }

            Rectangle rectangle = this.gameToUIObjects[drawableObject];
            rectangle.Width = drawableObject.ImageSource.Width;
            rectangle.Height = drawableObject.ImageSource.Height;
            rectangle.Fill = new ImageBrush(drawableObject.ImageSource);
            Canvas.SetLeft(rectangle, drawableObject.Position.X);
            Canvas.SetTop(rectangle, drawableObject.Position.Y);
        }

        private void AddObject(IDrawable drawableObject)
        {
            Rectangle rectangle = new Rectangle();
            this.Children.Add(rectangle);
            this.gameToUIObjects.Add(drawableObject, rectangle);
        }

        private void RemoveObject(IDrawable drawableObject)
        {
            this.Children.Remove(gameToUIObjects[drawableObject]);
            this.gameToUIObjects.Remove(drawableObject);
        }
    }
}