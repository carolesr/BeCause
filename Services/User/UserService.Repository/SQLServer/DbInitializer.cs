using System;
using System.Linq;
using UserService.Domain.Entities;

namespace UserService.Repository.SQLServer
{
    public class DbInitializer
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
                    Active = true,
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
