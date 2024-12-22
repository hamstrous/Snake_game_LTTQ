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
        public static Color ogColor = Color.FromRgb(81, 130, 236), 
            ogDarkColor = Color.FromRgb(40, 64, 115),
            newColor;

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
                            if (Color.FromRgb(pixelData[index + 2], pixelData[index + 1], pixelData[index]) == ogColor)
                            {
                                pixelData[index] = newColor.B;     // Blue
                                pixelData[index + 1] = newColor.G; // Green
                                pixelData[index + 2] = newColor.R; // Red
                            }
                            else if (Color.FromRgb(pixelData[index + 2], pixelData[index + 1], pixelData[index]) == ogDarkColor)
                            {
                                Color col = Darken(newColor);
                                pixelData[index] = col.B;     // Blue
                                pixelData[index + 1] = col.G; // Green
                                pixelData[index + 2] = col.R; // Red
                            }

                            /*pixelData[index] = newColor.B;     // Blue
                            pixelData[index + 1] = newColor.G; // Green
                            pixelData[index + 2] = newColor.R; // Red*/
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
            Box = LoadImage("Box.png");
            Goal = LoadImage("Goal.png");
            Wall = LoadImage("Wall.png");
            
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

            switch (gameInit.SnakeColor)
            {
                   case SnakeColor.Blue:
                    newColor = Color.FromRgb(81, 130, 236);
                    break;
                case SnakeColor.Red:
                    newColor = Color.FromRgb(255, 0, 0);
                    break;
                case SnakeColor.Purple:
                    newColor = Color.FromRgb(128, 0, 128);
                    break;
                case SnakeColor.Pink:
                    newColor = Color.FromRgb(255, 192, 203);
                    break;
                case SnakeColor.Orange:
                    newColor = Color.FromRgb(244, 155, 60);
                    break;
                case SnakeColor.Cyan:
                    newColor = Color.FromRgb(0, 255, 255);
                    break;
            }

            Body = LoadImage("Body.png", true);
            Head = LoadImage("Head.png", true);
            DeadBody = LoadImage("DeadBody.png", true);
            DeadHead = LoadImage("DeadHead.png", true);
            DirectionPad = LoadImage("DirectionPad.png", true);
        }
    }
}
