using COMP1640_WebDev.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace COMP1640_WebDev.ViewModels
{
    public class CreateMagazine
    {        [Required(ErrorMessage = "Title can not be null")]
        public  string Title { get; set; }
 [Required(ErrorMessage = "Description can not be null")]
        public string Description { get; set; }
       
 [Required(ErrorMessage = "FacultyId can not be null")]
        public string FacultyId { get; set; }
        [Required(ErrorMessage = "AcademicYearId can not be null")]
        public required string AcademicYearId { get; set; }
       
    }
}
