using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostManagementSystem.Models
{
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CityID { get; set; }

        public string Name { get; set; }

        //tutaj można by zrobić relację że miasto ma wiele adresów ale raczej nie jest to potrzebne (wystarczy zrobić filtrację)

    }
}
