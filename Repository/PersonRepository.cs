using FinalExamBE.Database;
using FinalExamBE.Database.Entities;
using FinalExamBE.Interface;

namespace FinalExamBE.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly UsersDbContext _context;

        public PersonRepository(UsersDbContext context)
        {
            _context = context;
        }
        public Person Add(Person item)
        {
            _context.Add(item);
            _context.SaveChanges();
            return item;
        }

        public void Delete(Guid id)
        {
            _context.People.Remove(Get(id));
            _context.SaveChanges();
        }

        public Person Get(Guid id)
        {
            return _context.People.SingleOrDefault(x => x.Id == id);
        }
    }
}
