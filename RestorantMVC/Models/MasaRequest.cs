using System.ComponentModel.DataAnnotations;

namespace RestorantMVC.Models
{
    public class MasaRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Sifre { get; set; }
    }
}