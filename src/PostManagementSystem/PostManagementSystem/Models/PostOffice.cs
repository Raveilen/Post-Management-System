namespace PostManagementSystem.Models
{
    public class PostOffice
    {
        public Guid ID { get; set; }

        public int packageSCapacity { get; set; }
        public int packageMCapacity { get; set; }
        public int packageLCapacity { get; set; }

        public Address Address { get; set; }
    }
}
