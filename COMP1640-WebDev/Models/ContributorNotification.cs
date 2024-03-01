namespace COMP1640_WebDev.Models
{
    public class ContributorNotification
    {
        public int NotificationID { get; set; }
        public int ContributionID { get; set; }
        public int FacultyCoordinatorID { get; set; }
        public DateTime NotificationDate { get; set; }
    }
}
