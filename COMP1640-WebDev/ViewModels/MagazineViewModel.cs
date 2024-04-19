using COMP1640_WebDev.Models;
using System.ComponentModel.DataAnnotations;

namespace COMP1640_WebDev.ViewModels
{
	public class MagazineViewModel
	{
		public Magazine? Magazine { get; set; }
		public  IEnumerable<Faculty>? Falulties { get; set; }
		public  IEnumerable<AcademicYear>? AcademicYears { get; set;}
		[Display(Name = "File")]
		public IFormFile? FormFile { get; set; }
	}
}
