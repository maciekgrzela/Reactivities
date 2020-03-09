using API.Resources;
using AutoMapper;
using Domain;

namespace API.Mappings
{
    public class ModelToResourceProfile : Profile {
        public ModelToResourceProfile() {
            CreateMap<Activity, ActivityResource>();
        }
    }
}