using System.ComponentModel.DataAnnotations;

namespace Users_CRUD.ViewModels
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "username is required")]
        [MaxLength(40, ErrorMessage = "username must not exceeds 40 Chars")]
        [RegularExpression("^[A-Za-z0-9 ]+$", ErrorMessage = "username must contain chars or numbers only")]
        public string Username { get; set; }

        [Required(ErrorMessage = "password is required")]
        public string Password { get; set; }
        public string? UserFullName { get; set; }

        [Required(ErrorMessage = "date of birth is required")]
        public DateOnly DateOfBirth { get; set; }

    }
}
