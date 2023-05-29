using System.ComponentModel.DataAnnotations;

namespace UserAPI.Models
{
    public class User
    {
        [Key]
        public string Username { get; set; }
        public byte[]? Password { get; set; }
        public byte[]? HashKey { get; set; }
        [Required(ErrorMessage = "Phone number cant be empty")]
        public string? PhoneNumber { get; set; }
        [Required(ErrorMessage = "Name cant be empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Age cant be empty")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Role cant be empty")]
        public string Role { get; set; }

    }
}
