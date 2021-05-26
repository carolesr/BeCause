using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserService.Domain.Entities;
using UserService.Repository.CommandDB;
using UserService.Repository.Interfaces;

namespace UserService.Repository.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(Context context) : base(context) { }

        public void Create(User newUser)
        {
            try
            {
                Insert(newUser);
                Commit();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public User Retrieve(int id)
        {
            if (id <= 0)
                throw new Exception("id invalido");

            return Get().FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<User> RetrieveAll()
        {
            return Get().AsEnumerable();
        }

        //public void Dispose() { }
    }
}
