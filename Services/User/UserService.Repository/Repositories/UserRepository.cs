using UserService.Domain.Entities;
using UserService.Repository.CommandDB;
using UserService.Repository.Interfaces;

namespace UserService.Repository.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(Context context) : base(context) { }        
    }
}
