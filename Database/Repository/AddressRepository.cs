using FinalExamBE.Database;
using FinalExamBE.Database.Entities;
using FinalExamBE.Interface;
using FinalExamBE.Repository;

namespace FinalExamBE.Database.Repository
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        private readonly UsersDbContext _context;
        public AddressRepository(UsersDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
