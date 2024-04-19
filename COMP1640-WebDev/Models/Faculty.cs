using System.ComponentModel.DataAnnotations;

namespace COMP1640_WebDev.Models
{
    public class Faculty
    {
        [Key]
        [Required(ErrorMessage = "ID can not be null")]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required(ErrorMessage = "Faculty can not be null")]
        [StringLength(255)]
        public required string FacultyName { get; set; }
        public List<User>? Users { get; set; }
        public List<Magazine>? Magazines { get; set;}

    }

}
