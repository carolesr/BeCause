using Foundation.Core.Responses;
using System.Collections.Generic;
using System.Linq;
using UserService.Core.Services.Interfaces;
using UserService.Domain.Entities;
using UserService.Repository.Interfaces;

namespace UserService.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository) 
        {
            _repository = repository;
        }

        public List<User> GetAllUsers()
        {
            return _repository.Get().ToList();
        }

        public Response CreateUser(User user)
        {
            if (CPFAlreadyExists(user.CPF))
                return new Response($"User with CPF {user.CPF} already exists", false);

            _repository.Insert(user);
            return new Response("Success creating user", true);
        }

        private bool CPFAlreadyExists(string cpf)
        {
            return _repository.Get().Any(user => user.CPF == cpf);
        }
    }
}
