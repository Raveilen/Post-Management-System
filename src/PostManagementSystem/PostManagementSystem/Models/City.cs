namespace PostManagementSystem.Models
{
    public class City
    {
        public Guid ID { get; set; }

        public string Name { get; set; }
        public string PostalCode { get; set; }
        public long HashCode { get; set; }

        //tutaj można by zrobić relację że miasto ma wiele adresów ale raczej nie jest to potrzebne (wystarczy zrobić filtrację)

    }
}
