using System.ComponentModel.DataAnnotations;

namespace PostManagementSystem.Models
{
    public class Customer
    {
        [Key]
        public Guid ID { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Email { get; set; }
        public string Phone { get; set; }
        public long HashCode { get; set; }
    }
}
