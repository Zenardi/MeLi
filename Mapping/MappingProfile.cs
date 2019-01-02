using AutoMapper;
using meli.Controllers.Resources;
using meli.Models;

namespace meli.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Maker, MakerResource>();
            CreateMap<Model, ModelResource>();
            
        }
    }
}