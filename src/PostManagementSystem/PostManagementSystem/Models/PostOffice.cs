using System.ComponentModel.DataAnnotations;

namespace PostManagementSystem.Models
{
    public class PostOffice
    {
        [Key]
        public Guid PostOfficeID { get; set; }

        public int packageSCapacity { get; set; }
        public int packageMCapacity { get; set; }
        public int packageLCapacity { get; set; }

        public Address Address { get; set; }
    }
}
