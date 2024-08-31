using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostManagementSystem.Models
{
    public class PostOffice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PostOfficeID { get; set; }

        public int packageSCapacity { get; set; }
        public int packageMCapacity { get; set; }
        public int packageLCapacity { get; set; }

        public Guid AddressID { get; set; }
        public Address Address { get; set; }
    }
}
