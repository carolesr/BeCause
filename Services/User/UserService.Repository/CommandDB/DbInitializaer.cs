using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserService.Domain.Entities;

namespace UserService.Repository.CommandDB
{
    public static class DbInitializaer
    {
        public static void Initialize(Context context)
        {
            context.Database.EnsureCreated();

            if (context.User.Any())
                return;

            var users = new User[]
            {
                new User
                {
                    Name = "Caroline Rosa",
                    Email = "carol@gmail.com",
                    Phone = 1111111111,
                    Birthday = DateTime.Parse("1999-8-1"),
                    CPF = "120.780.589-04",
                    Picture = "",
                    City = "Curitiba",
                    Country = "Brasil"
                }
            };
            foreach (var user in users)
                context.User.Add(user);
            context.SaveChanges();
        }
    }
}
