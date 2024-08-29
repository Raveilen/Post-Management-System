using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostManagementSystem.Models
{
    public class Package
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        public Guid SenderID { get; set; }
        public Customer Sender { get; set; }

        public Guid ReceiverID { get; set; }
        public Customer Receiver { get; set; }

        public Guid PackageTypeID { get; set; }
        public PackageType Type{ get; set; }
    }
}
