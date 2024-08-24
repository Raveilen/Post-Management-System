namespace PostManagementSystem.Models
{
    public class Status
    {
        public Guid ID { get; set; }

        public string Name { get; set; }

        //tutaj podobnie, żeby odszukać paczki z tym samym statusem, wystarczy nam filtracja
    }
}
