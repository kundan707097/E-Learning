using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class UploadModel
    {
        [Key]
        public int id { get; set; }
        [Display(Name ="Full Name")]
        public string? name { get; set; }
        [Display(Name ="Email")]
        [Required, EmailAddress]
        public string? email { get; set; }
        [Display(Name ="Title")]
        public string? title { get; set; }
        public string? uploadUrl { get; set; }
        [Display(Name = "Upload the Document")]
        [Required]
        [NotMapped]
        public IFormFile fileUpload { get; set; }
    }
}
