using FinalExamBE.Database.Entities;
using FinalExamBE.Interface;
using FinalExamBE.Repository;
using Microsoft.EntityFrameworkCore;

namespace FinalExamBE.Database.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly UsersDbContext _context;

        public UserRepository(UsersDbContext context) : base(context)
        {
            _context = context;
        }

        public bool Exists(string user)
        {
            return _context.Users.Any(x => x.Username == user);
        }

        public User? Login(string user, string password)
        {
            User? userToken = _context.Users.Where(x => x.Username == user && x.Password == password).Include(p => p.Person).SingleOrDefault();

            _ = userToken != null ? userToken.Password = "" : null;

            return userToken;

        }

        public User UpdatePassword(string id, string password)
        {
            User user = base.Get(id);
            user.Password = password;
            _context.SaveChanges();
            return user;
        }

    }
}
