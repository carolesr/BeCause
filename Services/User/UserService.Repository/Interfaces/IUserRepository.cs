using System;
using System.Collections.Generic;
using UserService.Domain.Entities;

namespace UserService.Repository.Interfaces
{
    public interface IUserRepository : BaseIRepository<User>
    {
        void Create(User user);
        User Retrieve(int id);
        IEnumerable<User> RetrieveAll();
    }
}
