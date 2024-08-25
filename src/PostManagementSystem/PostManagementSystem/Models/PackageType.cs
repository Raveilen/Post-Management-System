using System.ComponentModel.DataAnnotations;

namespace PostManagementSystem.Models
{
    public class PackageType
    {
        [Key]
        public Guid PackageTypeID { get; set; }
        public string Name { get; set; } //S L lub M
        public int MaxWeight { get; set; }
        public string Dimensions { get; set; } //string opisujący wymiary paczki
        public decimal Cost { get; set; } //koszt wysyłki
        public byte[] Image { get; set; } //zdjęcie poglądowe paczki
    }
}
