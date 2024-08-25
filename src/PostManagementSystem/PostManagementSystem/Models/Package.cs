using System.ComponentModel.DataAnnotations;

namespace PostManagementSystem.Models
{
    public class Package
    {
        [Key]
        public Guid ID { get; set; }

        public Customer Sender { get; set; }
        public Customer Receiver { get; set; }

        public PackageType Type{ get; set; }
    }
}
