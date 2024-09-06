namespace PostManagementSystem.ViewModels
{
    public class PostOfficeViewModel
    {
        public Guid PostOfficeID { get; set; }
        public Guid AddressID { get; set; }
        public int SCapacity { get; set; }
        public int MCapacity { get; set; }
        public int LCapacity { get; set; }
    }
}
