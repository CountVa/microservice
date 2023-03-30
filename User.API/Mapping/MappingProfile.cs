using AutoMapper;
using User.API.Models;
using User.DB.Entitites;

namespace User.API.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DbUser, DtoUser>()
                .ReverseMap();
        }
    }
}
