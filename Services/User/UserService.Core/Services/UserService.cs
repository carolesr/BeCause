﻿using Foundation.Core.Responses;
using System.Collections.Generic;
using System.Linq;
using UserService.Core.Services.Interfaces;
using UserService.Domain.Entities;
using UserService.Repository.SQLServer.Interfaces;

namespace UserService.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository) 
        {
            _repository = repository;
        }

        public List<User> GetAllUsers(bool activeOnly = false)
        {
            return _repository.Get().Where(u => activeOnly ? u.Active : true).ToList();
        }

        public User GetUserById(int id)
        {
            return _repository.Get().FirstOrDefault(u => u.Id == id);
        }

        public Response CreateUser(User user)
        {
            if (CPFAlreadyExists(user.CPF))
                return new Response($"User with CPF {user.CPF} already exists", false);

            user.Active = true;
            _repository.Insert(user);

            return new Response("Success creating user", true);
        }

        private bool CPFAlreadyExists(string cpf)
        {
            return _repository.Get().Any(user => user.CPF == cpf);
        }
    }
}
