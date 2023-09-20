using Entites.Concrate;
using System.ComponentModel.DataAnnotations;

namespace RestorantMVC.Models
{
    public class FirmaRegisterDTO
    {

        [Required(AllowEmptyStrings =false,ErrorMessage ="Firma Adi Zorunludur")]
        public string FirmaAdi { get; set; }
        [Required(AllowEmptyStrings = false , ErrorMessage = "Email Adi Zorunludur")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false , ErrorMessage = "Password  Zorunludur")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false , ErrorMessage = "Password  Zorunludur")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Sifreler  uyumsuz")]
        public string RePassword { get; set; }
    }
}
