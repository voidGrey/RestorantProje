using DAL.Repository.Abstract;
using DAL.Repository.Concrete;
using Entites.Concrate;

namespace DAL.Repository.Concrate
{
    public class UrunRepository : BaseRepository<Urun>, IUrunRepository
    { }
}