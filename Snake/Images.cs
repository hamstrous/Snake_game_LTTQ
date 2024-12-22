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
        public static ImageSource Radish;
        public static ImageSource Apple;
        public static ImageSource Banana;
        public static ImageSource Grape;
        public static ImageSource Peach;
        public static ImageSource Bg1 = LoadImage("Bg1.png");
        public static ImageSource Bg2 = LoadImage("Bg2.png");
        public static Color ogColor = Color.FromRgb(81, 130, 236), newColor;

        private static Color Darken(Color c)
        {
            Color dark = Color.FromRgb((byte)(c.R * 0.5), (byte)(c.G * 0.5), (byte)(c.B * 0.5));
            return dark;
        }

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
                            pixelData[index] = newColor.B;     // Blue
                            pixelData[index + 1] = newColor.G; // Green
                            pixelData[index + 2] = newColor.R; // Red
                        }
                    }
                }

                // Write the modified pixels back to the WriteableBitmap
                writableBitmap.WritePixels(new Int32Rect(0, 0, width, height), pixelData, stride, 0);
            }

            return writableBitmap;
        }

        public static void AssignImages(GameInit gameInit)
        {
            Empty = LoadImage("Empty.png");
            Body = LoadImage("Body.png");
            Head = LoadImage("Head.png");

            
            Box = LoadImage("Box.png");
            Goal = LoadImage("Goal.png");
            Wall = LoadImage("Wall.png");
            DirectionPad = LoadImage("DirectionPad.png");
            string foodLink = gameInit.FoodType switch
            {
                FoodType.Radish => "Radish.png",
                FoodType.Apple => "Apple.png",
                FoodType.Banana => "Banana.png",
                FoodType.Grape => "Grape.png",
                FoodType.Peach => "Peach.png",
                _ => throw new NotImplementedException()
            };
            Food = LoadImage(foodLink);

            DeadBody = LoadImage("DeadBody.png");
            DeadHead = LoadImage("DeadHead.png");
        }
    }
}
