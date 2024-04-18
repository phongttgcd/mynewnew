using COMP1640_WebDev.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace COMP1640_WebDev.ViewModels
{
	public class CreateContribute
	{
		public string AcademicYearId { get; set; }

		public string Title { get; set; }
		public string Document { get; set; }
	}
}
