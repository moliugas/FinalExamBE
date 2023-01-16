using Microsoft.EntityFrameworkCore;
using FinalExamBE.Database.Entities;

namespace FinalExamBE.Database
{
    public class UsersDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Address> Adresses { get; set; }

        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options) { }
    }
}
