using AutoMapper;
using Elfie.Serialization;
using Entites.Concrate;
using RestorantMVC.Models;

namespace RestorantMVC.AutoMapperConfig
{

    public class MyAutoMapper :Profile
    {
        public MyAutoMapper()
        {
            CreateMap<FirmaRegisterDTO , Firma>().ForMember(f => f.UserName , o => o.MapFrom(src => src.FirmaAdi));
            CreateMap<UrunModel , Urun>();
        }
    }
}
