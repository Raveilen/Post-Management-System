namespace PostManagementSystem.ViewModels
{
    public class PackageTypeViewModel
    {
        public string Name { get; set; }
        public int MaxWeight { get; set; }
        public string MaxDimensions { get; set; }
        public bool IsFragile { get; set; }
        public decimal Cost { get; set; }
    }
}
