using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Users_CRUD.Models
{
    public class User
    {
        [Required]
        public string Id { get; set; }
        [Required(ErrorMessage ="username is required")]
        [MaxLength(40 , ErrorMessage ="username must not exceeds 40 Chars")]
        [RegularExpression("^[A-Za-z0-9 ]+$" , ErrorMessage ="username must contain chars or numbers only")]
        public string Username { get; set; }
        
        [Required(ErrorMessage ="password is required")]
        public string Password { get; set; }
        public string? UserFullName { get; set;}
        public bool IsActive { get; set; } = true;
        [Required(ErrorMessage = "date of birth is required")]
        public DateOnly DateOfBirth { get; set; }
    }
}
