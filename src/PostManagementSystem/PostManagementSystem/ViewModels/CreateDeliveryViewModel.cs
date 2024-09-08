using PostManagementSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace PostManagementSystem.ViewModels
{
    public class CreateDeliveryViewModel
    {
        public Guid? PackageTypeID { get; set; }
        public PackageType? PackageType { get; set; }

        public Guid? SenderID { get; set; }
        public Customer? Sender { get; set; }

        public Guid? ReceiverID { get; set; }
        public Customer? Receiver { get; set; }

        public Guid? SenderOfficeID { get; set; }
        public PostOffice SenderOffice { get; set; }

        public Guid? ReceiverOfficeID { get; set; }
        public PostOffice ReceiverOffice { get; set; }

        public Guid? StatusID { get; set; }
        public Status? Status { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime CreateDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime ExpectedDeliveryDate { get; set; }
        public DateTime StatusUpdateDate { get; set; }

        public string UserEmail { get; set; }
    }
}
