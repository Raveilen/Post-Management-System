using System.Security.Policy;

namespace PostManagementSystem.Data
{
    public class ImageConverter
    {
        public static string pathToMainDirectory = Directory.GetCurrentDirectory();
        public static string pathToAssetsDirectory = $"{pathToMainDirectory}\\wwwroot\\img";

        public static string collectedImagePath = $"{pathToAssetsDirectory}\\Collected.jpg";
        public static string deliveredImagePath = $"{pathToAssetsDirectory}\\Delivered.jpg";
        public static string inTransitImagePath = $"{pathToAssetsDirectory}\\InTransit.jpg";
        public static string orderedImagePath = $"{pathToAssetsDirectory}\\Ordered.jpg";
        public static string packedImagePath = $"{pathToAssetsDirectory}\\Packed.jpg";
        public static string retunedImagePath = $"{pathToAssetsDirectory}\\Returned.jpg";

        public static string smallImagePath = $"{pathToAssetsDirectory}\\Small.jpg";
        public static string mediumImagePath = $"{pathToAssetsDirectory}\\Medium.jpg";
        public static string largeImagePath = $"{pathToAssetsDirectory}\\Large.jpg";
        public static string logoutImagePath = $"{pathToAssetsDirectory}\\Logout.jpg";

        public static byte[] ConvertImageToByteArray(string imagePath)
        {
            using (var memoryStream = new MemoryStream())
            {
                return File.ReadAllBytes(imagePath);
            }
        }
    }
}
