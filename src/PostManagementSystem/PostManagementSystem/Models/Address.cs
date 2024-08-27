using System.ComponentModel.DataAnnotations;

namespace PostManagementSystem.Models
{
    public class Address
    {
        [Key]
        public Guid ID { get; set; }

        public string Street { get; set; }
        public string DwellingNumber { get; set; }
        public string? ApartmentNumber { get; set; }
        public string PostalCode { get; set; }
        public long HashCode { get; set; }

        public City City { get; set; }

        private string apartmentPart => ApartmentNumber != null ? "m. " + ApartmentNumber : "";
        public string FullAddress => $"ul. {Street} {DwellingNumber} {ApartmentNumber}, {PostalCode} {City.Name}";
    }
}
