namespace PostManagementSystem.Data
{
    public class ImageConverter
    {
        public static byte[] ConvertImageToByteArray(string imagePath)
        {
            using (var memoryStream = new MemoryStream())
            {
                return File.ReadAllBytes(imagePath);
            }
        }
    }
}
