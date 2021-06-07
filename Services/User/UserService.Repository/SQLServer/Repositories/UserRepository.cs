using Foundation.Repository.SQLServer.Repositories;
using UserService.Domain.Entities;
using UserService.Repository.SQLServer.Interfaces;

namespace UserService.Repository.SQLServer.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(Context context) : base(context) { }
    }
}
