using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace PostManagementSystem.Models
{
    public class Delivery
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Delivery ID")]
        public Guid DeliveryID { get; set; }

        public string UserEmail { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Created")]
        public DateTime CreatedDate { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayName("Expected Delivery")]
        public DateTime ExpectedDeliveryDate { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayName("Status Update")]
        public DateTime StatusUpdateDate { get; set; }
        
        public Guid? StatusID { get; set; }
        public Status Status { get; set; }

        [DisplayName("From Post Office")]
        public Guid? SenderPostOfficeID { get; set; }
        public PostOffice SenderPostOffice { get; set; }

        [DisplayName("To Post Office")]
        public Guid? ReceiverPostOfficeID { get; set; }
        public PostOffice ReceiverPostOffice { get; set; }

        [DisplayName("Package ID")]
        public Guid? PackageID { get; set; }
        public Package Package { get; set; }
    }
}
