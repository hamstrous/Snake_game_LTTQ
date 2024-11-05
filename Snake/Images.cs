using System;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace Snake
{
    public static class Images
    {
        public static ImageSource Head => LoadImage("Head.png");
        public static ImageSource DeadHead => LoadImage("DeadHead.png");
        public static ImageSource Body => LoadImage("Body.png");
        public static ImageSource DeadBody => LoadImage("DeadBody.png");
        public static ImageSource Food => LoadImage("Food.png");
        public static ImageSource Empty => LoadImage("Empty.png");
        private static ImageSource LoadImage(string fileName)
        {
            return new BitmapImage(new Uri($"Assets/{fileName}", UriKind.Relative));
        }
    }
}
