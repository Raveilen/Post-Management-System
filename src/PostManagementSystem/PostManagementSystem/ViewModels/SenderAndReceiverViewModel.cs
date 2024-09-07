namespace PostManagementSystem.ViewModels
{
    public class SenderAndReceiverViewModel
    {
        //all nsecessary informations to pass next
        public Guid? PackageTypeID { get; set; }

        public string SenderName { get; set; }
        public string ReceiverName { get; set; }

        public string SenderSurname { get; set; }
        public string ReceiverSurname { get; set; }

        public string SenderPhone { get; set; }
        public string ReceiverPhone { get; set; }
    }
}
