using System.ComponentModel.DataAnnotations;

namespace PostManagementSystem.Models
{
    public class Package
    {
        public Guid ID { get; set; }

        public int Weight { get; set; }
        public string Dimensions { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime UpdatedDate { get; set; }

        public Customer Sender { get; set; }
        public Customer Receiver { get; set; }
        public Status Status { get; set; }
    }
}
