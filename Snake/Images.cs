using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;

namespace Snake
{
    public static class Images
    {
        public static ImageSource Empty;
        public static ImageSource Body;
        public static ImageSource Head;
        public static ImageSource Food;
        public static ImageSource DeadBody;
        public static ImageSource DeadHead;
        public static ImageSource Box;
        public static ImageSource Goal;
        public static ImageSource Wall;
        public static ImageSource DirectionPad;
        public static Color color;

        private static ImageSource LoadImage(string fileName, bool recolor = false)
        {
            // Load the original image
            BitmapImage originalImage = new BitmapImage();
            originalImage.BeginInit();
            originalImage.UriSource = new Uri($"pack://application:,,,/Assets/{fileName}", UriKind.Absolute);
            originalImage.EndInit();

            // Convert the BitmapImage to a writable format for pixel manipulation
            BitmapSource bitmapSource = new FormatConvertedBitmap(originalImage, PixelFormats.Bgra32, null, 0);
            WriteableBitmap writableBitmap = new WriteableBitmap(bitmapSource);

            if (recolor)
            {
                // Retrieve pixel data
                int width = writableBitmap.PixelWidth;
                int height = writableBitmap.PixelHeight;
                int stride = width * 4; // 4 bytes per pixel (BGRA format)
                byte[] pixelData = new byte[height * stride];

                writableBitmap.CopyPixels(pixelData, stride, 0);
                
                // Modify pixel data
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        int index = (y * stride) + (x * 4);
                        byte alpha = pixelData[index + 3];

                        if (alpha > 0) // Process only non-transparent pixels
                        {
                            // Calculate intensity of the original pixel
                            // double intensity = (0.3 * pixelData[index + 2] + 0.59 * pixelData[index + 1] + 0.11 * pixelData[index]) / 255.0;

                            // Apply the new color while preserving intensity
                            pixelData[index] = color.B;     // Blue
                            pixelData[index + 1] = color.G; // Green
                            pixelData[index + 2] = color.R; // Red
                        }
                    }
                }

                // Write the modified pixels back to the WriteableBitmap
                writableBitmap.WritePixels(new Int32Rect(0, 0, width, height), pixelData, stride, 0);
            }

            return writableBitmap;
        }

        public static void AssignImages()
        {
            Empty = LoadImage("Empty.png");
            Body = LoadImage("Body.png");
            Head = LoadImage("Head.png");
            Food = LoadImage("Food.png", true);
            DeadBody = LoadImage("DeadBody.png");
            DeadHead = LoadImage("DeadHead.png");
            Box = LoadImage("Box.png");
            Goal = LoadImage("Goal.png");
            Wall = LoadImage("Wall.png");
            DirectionPad = LoadImage("DirectionPad.png");
        }
    }
}
