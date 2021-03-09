using AutoMapper;
using UserService.Core.Responses;
using UserService.Core.Requests;
using UserService.Domain.Entities;

namespace UserService.Core.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserRequest, User>();
            CreateMap<User, CreateUserResponse>();
        }
    }
}
