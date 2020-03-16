using API.Resources;
using AutoMapper;
using Domain;

namespace API.Mappings
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveActivityResource, Activity>();
        }
    }
}