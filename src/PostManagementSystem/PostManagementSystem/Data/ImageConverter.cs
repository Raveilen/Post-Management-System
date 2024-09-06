using System.Security.Policy;

namespace PostManagementSystem.Data
{
    public class ImageConverter
    {
        public static string pathToMainDirectory = Directory.GetCurrentDirectory();
        public static string pathToAssestDirectory = $"{pathToMainDirectory}\\wwwroot\\img";

        public static string collectedImagePath = $"{pathToAssestDirectory}\\Collected.jpg";
        public static string deliveredImagePath = $"{pathToAssestDirectory}\\Delivered.jpg";
        public static string inTransitImagePath = $"{pathToAssestDirectory}\\InTransit.jpg";
        public static string orderedImagePath = $"{pathToAssestDirectory}\\Ordered.jpg";
        public static string packedImagePath = $"{pathToAssestDirectory}\\Packed.jpg";
        public static string retunedImagePath = $"{pathToAssestDirectory}\\Returned.jpg";

        public static string smallImagePath = $"{pathToAssestDirectory}\\Small.jpg";
        public static string mediumImagePath = $"{pathToAssestDirectory}\\Medium.jpg";
        public static string largeImagePath = $"{pathToAssestDirectory}\\Large.jpg";
        public static string logoutImagePath = $"{pathToAssestDirectory}\\Logout.jpg";

        public static byte[] ConvertImageToByteArray(string imagePath)
        {
            using (var memoryStream = new MemoryStream())
            {
                return File.ReadAllBytes(imagePath);
            }
        }
    }
}
