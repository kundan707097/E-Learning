using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class ChatModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Sender")]
        public string? sender { get; set; }
        [Required]
        [Display(Name ="Message")]
        public string? message { get; set; }
        [Required]
        [Display(Name ="Receiver")]
        public string? receiver { get; set; }
    }
}
