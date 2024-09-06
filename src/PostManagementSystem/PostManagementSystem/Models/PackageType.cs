using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostManagementSystem.Models
{
    public class PackageType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PackageTypeID { get; set; }
        public string Name { get; set; } //S L lub M

        public int MaxWeight { get; set; }
        public string MaxDimensions { get; set; } //string opisujący wymiary paczki

        public bool IsFragile { get; set; } //czy paczka jest łamliwa

        [DataType(DataType.Currency)]
        public decimal Cost { get; set; } //koszt wysyłki
        public byte[] Image { get; set; } //zdjęcie poglądowe paczki
    }
}
