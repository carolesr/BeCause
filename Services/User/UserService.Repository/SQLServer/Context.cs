using Microsoft.EntityFrameworkCore;
using UserService.Domain.Entities;

namespace UserService.Repository.SQLServer
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<User> User { get; set; }
        //public DbSet<Account> Account { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            //modelBuilder.Entity<Account>().ToTable("Account");
        }
    }
}
