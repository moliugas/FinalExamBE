using FinalExamBE.Database.Entities;
using FinalExamBE.Interface;
using FinalExamBE.Repository;

namespace FinalExamBE.Database.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly UsersDbContext _context;

        public UserRepository(UsersDbContext context) : base(context)
        {
            _context = context;
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
