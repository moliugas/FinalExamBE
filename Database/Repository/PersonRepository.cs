using FinalExamBE.Database;
using FinalExamBE.Database.Entities;
using FinalExamBE.Interface;
using FinalExamBE.Repository;

namespace FinalExamBE.Database.Repository
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        private readonly UsersDbContext _context;

        public PersonRepository(UsersDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
