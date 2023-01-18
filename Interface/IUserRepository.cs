using FinalExamBE.Database.Entities;

namespace FinalExamBE.Interface
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User UpdatePassword(string id, string pass);
    }
}