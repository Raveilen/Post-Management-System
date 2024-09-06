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



        public string FullAddress
        {
            get
            {
                var cityName = City?.Name ?? "Unknown City";
                var apartmentPart = !string.IsNullOrEmpty(ApartmentNumber) ? "m. " + ApartmentNumber : "";
                return $"ul. {Street} {DwellingNumber} {apartmentPart}, {PostalCode} {cityName}";
            }
        }

        public string AddresKey
        {
            get
            {
                var cityName = City?.Name ?? "Unknown City";
                return $"{Street}{DwellingNumber}{ApartmentNumber}{PostalCode}{cityName}";
            }
        }
            

        //key for adresses identification (check if unique)
      
    }
}
