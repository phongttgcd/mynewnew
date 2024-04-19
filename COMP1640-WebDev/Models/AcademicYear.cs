using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace COMP1640_WebDev.Models
{
    public class AcademicYear
    {
        [Key]
        public string Id { get; set; }=Guid.NewGuid().ToString();

        public DateTime FinalDate { get; set; }
        public DateTime ClosureDate { get; set; }
        public DateTime StartDate { get; set; }

		public List<Magazine>? Magazines { get; set; }

	}
}
