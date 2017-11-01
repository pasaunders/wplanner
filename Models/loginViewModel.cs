using System.ComponentModel.DataAnnotations;

namespace weddingPlanner.Models
{
    public class loginViewModel
    {
        [Required]
        public string email {get; set;}
        [Required]
        public string password {get; set;}
    }
}