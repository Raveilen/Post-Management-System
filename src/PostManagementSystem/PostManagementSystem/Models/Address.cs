using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostManagementSystem.Models
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AddressID { get; set; }

        public string Street { get; set; }
        public string DwellingNumber { get; set; }
        public string? ApartmentNumber { get; set; }
        public string PostalCode { get; set; }

        public Guid CityID { get; set; }
        public City City { get; set; }

        private string apartmentPart => ApartmentNumber != null ? "m. " + ApartmentNumber : "";
        public string FullAddress => $"ul. {Street} {DwellingNumber} {ApartmentNumber}, {PostalCode} {City.Name}";

        //key for adresses identification (check if unique)
        public string AddressKey => $"{Street}{DwellingNumber}{ApartmentNumber}{PostalCode}{City.Name}";
    }
}
