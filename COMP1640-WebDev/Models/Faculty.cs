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
        public string FacultyName { get; set; } = string.Empty;
        public List<User>? Users { get; set; }
        public List<AcademicYear>? AcademicYears { get; set; }  

    }

}
