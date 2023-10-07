using Entites.Concrate;
using System.ComponentModel.DataAnnotations;

namespace RestorantMVC.Models
{
    public class UrunModelDTO
    {
        // Base Entity
        public int ID { get; set; }

        public string? FirmaId { get; set; }
        public Firma? Firma { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }

        // Urun
        public string? UrunAdi { get; set; }
        public string? UrunAciklama { get; set; }
        public string? FotografLink { get; set; }
        public double Fiyat { get; set; }

        [Display(Name = "Add a picture")]
        [DataType(DataType.Upload)]
        [FileExtensions(Extensions = "jpg,png,gif,jpeg,bmp,svg")]
        public IFormFile uploadImage { get; set; }
        //Kategori ile ilişki

        public int KategoriID { get; set; }
        public Kategori Kategori { get; set; }
    }
}
