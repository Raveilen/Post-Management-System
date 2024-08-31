using System.Security.Policy;

namespace PostManagementSystem.Data
{
    public class ImageConverter
    {
        public static string pathToMainDirectory = Directory.GetCurrentDirectory();
        public static string pathToAssestDirectory = $"{pathToMainDirectory}\\wwwroot\\img";

        public static string collectedImagePath = $"{pathToAssestDirectory}\\Collected.svg";
        public static string deliveredImagePath = $"{pathToAssestDirectory}\\Delivered.svg";
        public static string inTransitImagePath = $"{pathToAssestDirectory}\\InTransit.svg";
        public static string orderedImagePath = $"{pathToAssestDirectory}\\Ordered.svg";
        public static string packedImagePath = $"{pathToAssestDirectory}\\Packed.svg";
        public static string retunedImagePath = $"{pathToAssestDirectory}\\Returned.svg";

        public static string smallImagePath = $"{pathToAssestDirectory}\\Small.jpg";
        public static string mediumImagePath = $"{pathToAssestDirectory}\\Medium.jpg";
        public static string largeImagePath = $"{pathToAssestDirectory}\\Large.jpg";

        public static byte[] ConvertImageToByteArray(string imagePath)
        {
            using (var memoryStream = new MemoryStream())
            {
                return File.ReadAllBytes(imagePath);
            }
        }
    }
}
