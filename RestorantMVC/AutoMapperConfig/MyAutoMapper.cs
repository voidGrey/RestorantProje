using AutoMapper;
using Entites.Concrate;
using RestorantMVC.Models;

namespace RestorantMVC.AutoMapperConfig
{
    public class MyAutoMapper :Profile
    {
        public MyAutoMapper()
        {
            CreateMap<FirmaRegisterDTO , Firma>();
        }
    }
}
