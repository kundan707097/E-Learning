using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Register
    {
        [Required]
        [Display(Name = "First Name")]
        public string? firstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string? lastName { get; set; }
        [Key]
        [Required]
        [EmailAddress]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [Display(Name = "Email")]
        public string? email { get; set; }
        [Required]
        [Display(Name = "Choice your Role")]
        public RollTypes rollTypes { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string? password { get; set; }
        [Compare("password", ErrorMessage = " Password Do don't Match")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string? confirmPassword { get; set; }
    }
}
