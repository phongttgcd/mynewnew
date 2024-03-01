namespace COMP1640_WebDev.Models
{
    public class Contributions
    {
        public int ContributionID { get; set; }
        public int UserID { get; set; }
        public int FacultyID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public DateTime SubmissionDate { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsSelected { get; set; }
        public string Comment { get; set; }
        public DateTime CommentDate { get; set; }
    }
}
