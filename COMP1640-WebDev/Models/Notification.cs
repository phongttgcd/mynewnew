using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace COMP1640_WebDev.Models
{
    public class Notification
    {
        [Key]
        public string Id { get; set; }=Guid.NewGuid().ToString();
        
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("Contribution")]
        public string ContributionId { get; set; }
        public Contribution Contribution { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}
