using COMP1640_WebDev.Models;
using System.ComponentModel.DataAnnotations;

namespace COMP1640_WebDev.ViewModels
{
	public class MagazineViewModel
	{
		public string? Title { get; set; }
		public string? Description { get; set; }
		public string? CoverImage { get; set; }
		public DateTime FinalDate { get; set; }
		public DateTime ClosureDate { get; set; }
		public DateTime StartDate { get; set; }
		public string AcademicYearId { get; set; }
	}
}
