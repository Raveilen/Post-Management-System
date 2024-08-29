using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostManagementSystem.Models
{
    public class Status
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid StatusID { get; set; }

        public string Name { get; set; }
        public byte[] Image { get; set; } //zdjęcie poglądowe statusu

        //tutaj podobnie, żeby odszukać paczki z tym samym statusem, wystarczy nam filtracja
    }
}
