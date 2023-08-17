using System.ComponentModel.DataAnnotations;

namespace RestorantMVC.Areas.Admin.Models
{
    public class QRCodeModel
    {
        [Display(Name = "Enter QRCode Text")]
        public string QRCodeText { get; set; }
    }
}