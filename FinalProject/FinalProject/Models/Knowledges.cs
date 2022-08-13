using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Knowledges
    {
        public int Id { get; set; }
        [Display(Name = "Email")]
        [Required]
        [EmailAddress]
        public string? email { get; set; }
        [Display(Name = "Title")]
        [Required]
        public string? title { get; set; }
        [Display(Name = "Write Article")]
        public string? Description { get; set; }
        [Display(Name = "Author Name")]
        [Required]
        public string? authorName { get; set; }
        [Display(Name = "Date Of Publish")]
        public DateTime PublicDate { get; set; }
    }
}
