using FinalExamBE.Database;
using FinalExamBE.Database.Entities;
using FinalExamBE.Interface;

namespace FinalExamBE.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UsersDbContext _context;

        public UserRepository(UsersDbContext context)
        {
            _context = context;
        }

        public User Add(User item)
        {
            _context.Add(item);
            _context.SaveChanges();
            return item;
        }

        public User Get(Guid id)
        {
            return _context.Users.SingleOrDefault(x => x.Id == id);
        }

        public void Delete(Guid id)
        {
            _context.Users.Remove(Get(id));
            _context.SaveChanges();
        }

        public void UpdatePassword(Guid id, string password)
        {
            var user = _context.Users.Single(x => x.Id == id);
            user.Password = password;
            _context.SaveChanges();
        }

    }
}
