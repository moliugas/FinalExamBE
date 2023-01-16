using FinalExamBE.Database.Entities;
using FinalExamBE.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FinalExamBE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : Controller
    {
        private readonly IPersonRepository _personRepo;

        public PersonController(IPersonRepository repo)
        {
            _personRepo = repo;
        }

        [HttpPost]
        [Route("Add")]
        public Person Add([FromBody] PersonDTO item)
        {
            return _personRepo.Add(new()
            {
                Name = item.Name,
                Lastname = item.Lastname,
                PersonalCode = item.PersonalCode,
                PhoneNumber = item.PhoneNumber,
                Email = item.Email,
                ProfilePicture = item.ProfilePicture,
                AddressId = item.AddressId
            });
        }
    }
}
