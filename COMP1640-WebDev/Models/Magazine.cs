using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace COMP1640_WebDev.Models
{
    public class Magazine
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Title of magazine can not be null")]
        [StringLength(255)]
        public string? Title {  get; set; } 
        public string? Description { get; set; }
        public byte[]? CoverImage { get; set; }


        [Required]
        [ForeignKey("Faculty")]
        public string? FacultyId { get; set; } 
        public Faculty? Faculty { get; set; }
    }
}
