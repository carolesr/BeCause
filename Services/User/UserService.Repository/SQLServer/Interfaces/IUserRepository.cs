using Foundation.Repository.SQLServer.Interfaces;
using UserService.Domain.Entities;

namespace UserService.Repository.SQLServer.Interfaces
{
    public interface IUserRepository : BaseIRepository<User>
    {
    }
}
