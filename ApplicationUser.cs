using System.ComponentModel.DataAnnotations;

namespace PROG3A_POE.Models
{
    public class ApplicationUser
    {
        public string Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string PasswordHash { get; set; } // for simplicity and testing
        public string Role { get; internal set; }
    }
}
