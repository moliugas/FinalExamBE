using FinalExamBE.Database.Entities;

namespace FinalExamBE.Interface
{
    public interface IUserRepository
    {
        public void Add(User user);
        public User Get(Guid id);
        public void Delete(Guid id);
    }
}