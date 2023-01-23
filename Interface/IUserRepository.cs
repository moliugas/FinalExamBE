using FinalExamBE.Database.Entities;

namespace FinalExamBE.Interface
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User UpdatePassword(string id, string pass);
        User? Login(string user, string password);
        bool Exists(string user);
    }
}