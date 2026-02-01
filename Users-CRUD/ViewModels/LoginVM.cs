using System.ComponentModel.DataAnnotations;

namespace Users_CRUD.ViewModels
{
    public class LoginVM
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
