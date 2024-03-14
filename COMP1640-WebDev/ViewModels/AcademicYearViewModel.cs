using COMP1640_WebDev.Models;
using System.ComponentModel.DataAnnotations;

namespace COMP1640_WebDev.ViewModels
{
    public class AcademicYearViewModel
    {
        public AcademicYear AcademicYear { get; set; } = new AcademicYear();
        public IEnumerable<Faculty>? Falculties { get; set; }
    }
}
