using AutoMapper;
using UserService.Core.Requests;
using UserService.Core.Responses;
using UserService.Domain.Entities;

namespace UserService.Core.Mappers
{
    class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<CreateUserRequest, User>().ReverseMap();
            CreateMap<User, CreateUserResponse>().ReverseMap() ;
        }
    }
}
