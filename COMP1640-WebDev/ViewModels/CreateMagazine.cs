using COMP1640_WebDev.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace COMP1640_WebDev.ViewModels
{
    public class CreateMagazine
    {

        public string? Title { get; set; }
        public string? Description { get; set; }
      
        public  string FacultyId { get; set; }
        public  string AcademicYearId { get; set; }
    }
}
