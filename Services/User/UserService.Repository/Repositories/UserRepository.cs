using System;
using System.Collections.Generic;
using System.Text;
using UserService.Domain.Entities;
using UserService.Repository.CommandDB;

namespace UserService.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;
        public UserRepository(Context context)
        {
            _context = context;
        }

        public User Create(User newUser)
        {
            try
            {
                _context.Add(newUser);
                _context.SaveChangesAsync();
                return newUser;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void Dispose() { }
    }
}
