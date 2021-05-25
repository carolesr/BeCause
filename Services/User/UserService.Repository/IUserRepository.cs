using System;
using System.Collections.Generic;
using System.Text;
using UserService.Domain.Entities;

namespace UserService.Repository
{
    public interface IUserRepository : IDisposable
    {
        User Create(User user);
    }
}
