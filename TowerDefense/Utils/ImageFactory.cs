namespace TowerDefense.Utils
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows;
    using System.Windows.Media.Imaging;

    public static class ImageFactory
    {
        private static IDictionary<string, BitmapSource> cache = new Dictionary<string, BitmapSource>();
        private static IDictionary<BitmapSource, CroppedBitmap[,]> croppedCache = new Dictionary<BitmapSource, CroppedBitmap[,]>();

        public static BitmapSource CreateImage(string fileName)
        {
            if (cache.ContainsKey(fileName))
            {
                return cache[fileName];
            }

            string path = Path.Combine(Environment.CurrentDirectory, "..", "..", "images", fileName);
            BitmapSource image = new BitmapImage(new Uri(path));
            cache[fileName] = image;
            return image;
        }

        public static CroppedBitmap CreateCroppedImage(BitmapSource source, int rows, int columns, int row, int column)
        {
            if(croppedCache.ContainsKey(source))
            {
                return croppedCache[source][row, column];
            }

            CroppedBitmap[,] croppedImages = new CroppedBitmap[rows, columns];
            int width = (int)source.Width / columns;
            int height = (int)source.Height / rows;
            for (int i = 0; i < rows; i++)
            {
                for(int j = 0; j < columns; j++)
                {
                    int x = j * width;
                    int y = i * height;
                    croppedImages[i, j] = new CroppedBitmap(source, new Int32Rect(x, y, width, height));
                }
            }

            croppedCache[source] = croppedImages;

            return croppedImages[row, column];
        }
    }
}
