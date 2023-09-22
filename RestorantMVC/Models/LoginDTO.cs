using System.ComponentModel.DataAnnotations;

namespace RestorantMVC.Models
{
    public class LoginDto
    {

        [Required(AllowEmptyStrings = false , ErrorMessage = "Email Adresi Zorunlduru")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        //[Required(AllowEmptyStrings = true, ErrorMessage = "Şifre Zorunldur")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
