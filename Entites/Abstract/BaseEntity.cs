using Entites.Concrate;

namespace Entites.Abstract
{
    public class BaseEntity
    {
        public int ID { get; set; }

        public string? FirmaId { get; set; }
        public Firma? Firma { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }

}