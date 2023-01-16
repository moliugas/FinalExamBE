using FinalExamBE.Database.Entities;

namespace FinalExamBE.Interface
{
    public interface IPersonRepository
    {
        public Person Add(Person item);
        public Person Get(Guid id);
        public void Delete(Guid id);
    }
}