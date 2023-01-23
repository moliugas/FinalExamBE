using FinalExamBE.Database;
using FinalExamBE.Database.Entities;

namespace FinalExamBE.Repository
{
    public class GenericRepository<T> where T : GenericEntity
    {
        private readonly UsersDbContext _context;
        public GenericRepository(UsersDbContext context)
        {
            _context = context;
        }

        public T Add(T item)
        {
            _context.Add(item);
            _context.SaveChanges();
            return item;
        }

        public void Delete(string id)
        {
            var entity = Get(new(id));

            if (entity == null)
            {
                return;
            }

            _context.Remove(entity);
            _context.SaveChanges();
        }

        public T Get(string id)
        {
            return _context.Set<T>().Single(x => x.Id == new Guid(id));
        }

        public List<T> Get()
        {
            return _context.Set<T>().ToList();
        }

        public T Update(string id, T item)
        {
            var entity = Get(new(id));

            if (entity == null)
            {
                throw new Exception();
            }

            _context.Update(entity);
            _context.SaveChanges();

            return item;
        }
    }
}
