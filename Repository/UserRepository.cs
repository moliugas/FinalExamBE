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

        public void Add(User item)
        {
            _context.Add(item);
            _context.SaveChanges();
        }

        public User Get(Guid id)
        {
            return _context.Users.SingleOrDefault(x => x.Id == id);
        }

        public void Delete(Guid id)
        {
            _context.Users.Remove(Get(id));
        }

    }
}
