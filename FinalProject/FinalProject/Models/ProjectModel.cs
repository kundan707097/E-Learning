using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class ProjectModel
    {
        [Key]
        public int Id { get; set; }
       
        [Display(Name = "Full Name")]
        public string? fullName { get; set; }
        [Display(Name ="Project Title")]
        public string? title { get; set; }
        [Display(Name ="Comment")]
        public string? comment { get; set; }
        public string? projectUrl { get; set; }
        [Required,Display(Name ="Upload Project")]
       
        [NotMapped]
        public IFormFile projectfile { get; set; }
    }
}
