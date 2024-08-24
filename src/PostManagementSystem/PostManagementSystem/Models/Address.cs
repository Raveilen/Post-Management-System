namespace PostManagementSystem.Models
{
    public class Address
    {
        public Guid ID { get; set; }

        public string Street { get; set; }
        public string DwellingNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public long HashCode { get; set; }

        public City City { get; set; }
    }
}
