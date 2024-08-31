using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace PostManagementSystem.Models
{
    public class Delivery
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid DeliveryID { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime ExpectedDeliveryDate { get; set; } //depends on the package priority (standard or express)
        [DataType(DataType.Date)]
        public DateTime StatusUpdateDate { get; set; }
        
        public Guid StatusID { get; set; }
        public Status Status { get; set; }

        public Guid SenderPostOfficeID { get; set; }
        public PostOffice SenderPostOffice { get; set; }

        public Guid ReceiverPostOfficeID { get; set; }
        public PostOffice ReceiverPostOffice { get; set; }

        public Guid PackageID { get; set; }
        public Package Package { get; set; }
    }
}
