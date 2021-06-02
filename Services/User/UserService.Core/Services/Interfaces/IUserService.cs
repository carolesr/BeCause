using Foundation.Core.Responses;
using System.Collections.Generic;
using UserService.Domain.Entities;

namespace UserService.Core.Services.Interfaces
{
    public interface IUserService
    {
        Response CreateUser(User user);

        List<User> GetAllUsers();
    }
}
