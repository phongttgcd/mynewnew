using System.ComponentModel.DataAnnotations;

namespace COMP1640_WebDev.Models
{
    public class Faculty
    {
        [Key] 
        public string Id { get; set; }=string.Empty;
        public string FacultyName { get; set; } = string.Empty;
        public List<User>? Users { get; set; }
        public List<AcademicYear>? AcademicYears { get; set; }  
    }

}
