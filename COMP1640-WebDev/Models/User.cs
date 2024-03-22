using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace COMP1640_WebDev.Models
{
    public class User : IdentityUser
    {
        [ForeignKey("Faculty")]
        public string? FacultyId { get; set; }
        public Faculty? Faculty { get; set; }
        public DateTime CreatedTime { get; set; }
        public List<Notification>? Notifications { get; set; }
        public List<Contribution>? Contributions { get; set;} 
    }
}
