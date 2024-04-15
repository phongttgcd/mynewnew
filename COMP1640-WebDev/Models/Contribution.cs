using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace COMP1640_WebDev.Models
{
    public class Contribution
    {
        [Key]
        public string Id { get; set; }=Guid.NewGuid().ToString();

        [ForeignKey("User")]
        public string? UserId { get; set; }
        public User? User { get; set; }  
        
        [ForeignKey("AcademicYear")]
        public string AcademicYearId { get; set; } = string.Empty;
        public AcademicYear AcademicYear { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Document { get; set; } = string.Empty;
        public byte[] Image { get; set; }
        public DateTime SubmissionDate { get; set; }=DateTime.Now;
        public bool IsEnabled { get; set; }
        public bool IsSelected { get; set; }
        public string Comment { get; set; } = string.Empty;
        public DateTime CommentDate { get; set; }
    }
}
