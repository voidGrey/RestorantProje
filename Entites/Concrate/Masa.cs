using Entites.Abstract;

namespace Entites.Concrate
{
    public class Masa : BaseEntity
    {
        public int MasaID { get; set; }
        public string? MasaSifresi { get; set; }
        public virtual List<SiparisMaster> Siparisler { get; set; }

        public string SifreOlustur()
        {
            Random random = new Random();
            int password = random.Next(1000, 9999);
            return password.ToString();
        }
    }
}