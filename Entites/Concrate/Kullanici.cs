using Entites.Abstract;

namespace Entites.Concrate
{
    public class Kullanici : BaseEntity
    {
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
    }
}