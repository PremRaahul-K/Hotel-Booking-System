using System.ComponentModel.DataAnnotations;

namespace UserAPI.Models.DTO
{
    public class UserRegisterDTO:User
    {
        [Required(ErrorMessage = "Password cant be empty")]
        public string PasswordClear { get; set; }
    }
}
