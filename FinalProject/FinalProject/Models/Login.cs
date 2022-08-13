using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Login
    {
        [Required, EmailAddress]
        public string? email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? password { get; set; }
        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}
