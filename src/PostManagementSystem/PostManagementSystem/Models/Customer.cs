using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostManagementSystem.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Email { get; set; }
        public string Phone { get; set; }

        public string CustomerKey => $"{Name}{Surname}{Email}{Phone}";
    }
}
