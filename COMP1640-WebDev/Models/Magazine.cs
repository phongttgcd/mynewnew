using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace COMP1640_WebDev.Models
{
    public class Magazine
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required(ErrorMessage ="Title of magazine can not be null")]
        [StringLength(255)]
        public string? Title {  get; set; } 
        public string? Description { get; set; }
        public byte[] CoverImage { get; set; }


        //[Required]
        [Display(Name = "Faculty")]
        [ForeignKey("Faculty")]
        public string? FacultyId { get; set; } 
        public Faculty? Faculty { get; set; }


 
    }
}
