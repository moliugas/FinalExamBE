namespace FinalExamBE.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        public T Add(T item);
        public T Get(string id);
        public List<T> Get();
        public T Update(string id, T item);
        public void Delete(string id);
    }
}