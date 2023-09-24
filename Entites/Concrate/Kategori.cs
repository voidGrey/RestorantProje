using Entites.Abstract;

namespace Entites.Concrate
{
    public class Kategori : BaseEntity
    {
        public string? KategoriAdi { get; set; }
        public string? KategoriAciklama { get; set; }
        public int? SelfKategoriID { get; set; }

        public ICollection<Urun>? Stoklar { get; set; }
    }
}