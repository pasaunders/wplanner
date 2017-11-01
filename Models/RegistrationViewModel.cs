using System.ComponentModel.DataAnnotations;

namespace weddingPlanner.Models
{
    public class RegistrationViewModel
    {
        [Required]
        public string firstName {get; set;}
        [Required]
        public string lastName {get; set;}
        [Required]
        [EmailAddress]
        public string email {get; set;}
        [Required]
        public string password {get; set;}
        [Required]
        [Compare("password", ErrorMessage="must match")]
        public string comparePassword {get; set;}
    }
}