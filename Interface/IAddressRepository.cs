using FinalExamBE.Database.Entities;

namespace FinalExamBE.Interface
{
    public interface IAddressRepository
    {
        public Address Add(Address user);
        public Address Get(Guid id);
        public void Delete(Guid id);
    }
}