using FinalExamBE.Database.Entities;
using FinalExamBE.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalExamBE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : Controller
    {
        private readonly IPersonRepository _repo;

        public PersonController(IPersonRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        [Route("Add")]
        public ActionResult<Person> Add([FromBody] PersonDTO item)
        {
            try
            {
                Person person = _repo.Add(new()
                {
                    Name = item.Name,
                    Lastname = item.Lastname,
                    PersonalCode = item.PersonalCode,
                    PhoneNumber = item.PhoneNumber,
                    Email = item.Email,
                    ProfilePicture = item.ProfilePicture
                });
                return Ok(person);
            }
            catch (Exception)
            {
                return BadRequest("Something wrong.");
            }
        }

        [HttpGet]
        public ActionResult<List<Person>> Get()
        {

            try
            {
                List<Person> items = _repo.Get();
                return Ok(items);
            }
            catch (Exception)
            {
                return NoContent();
            }
        }

        [HttpGet("id")]
        public ActionResult<Person> Get([FromQuery] string id)
        {
            try
            {
                Person item = _repo.Get(id);
                return Ok(item);
            }
            catch (Exception)
            {
                return NoContent();
            }
        }

        [HttpPost("update")]
        public ActionResult<Person> Update([FromBody] PersonDTO item)
        {
            Person person = _repo.Get(item.Id);
            if (person == null)
            {
                return BadRequest();
            }
            person.Name = item.Name;
            person.Lastname = item.Lastname;
            person.PersonalCode = item.PersonalCode;
            person.PhoneNumber = item.PhoneNumber;
            person.Email = item.Email;
            return _repo.Update(item.Id, person);
        }

        [HttpPut("Name")]
        public ActionResult<Person> PutName([FromQuery] string id, [FromQuery] string value)
        {
            Person person = _repo.Get(id);
            person.Name = value;
            return _repo.Update(id, person);
        }

        [HttpPut("Surname")]
        public ActionResult<Person> PutLastname([FromQuery] string id, [FromQuery] string value)
        {
            Person person = _repo.Get(id);
            person.Lastname = value;
            return _repo.Update(id, person);
        }

        [HttpPut("PersonalId")]
        public ActionResult<Person> PutPersonalCode([FromQuery] string id, [FromQuery] string value)
        {
            Person person = _repo.Get(id);
            person.PersonalCode = value;
            return _repo.Update(id, person);
        }

        [HttpPut("Phone")]
        public ActionResult<Person> PutPhone([FromQuery] string id, [FromQuery] string value)
        {
            Person person = _repo.Get(id);
            person.PhoneNumber = value;
            return _repo.Update(id, person);
        }

        [HttpPut("Email")]
        public ActionResult<Person> PutEmail([FromQuery] string id, [FromQuery] string value)
        {
            Person person = _repo.Get(id);
            person.Email = value;
            return _repo.Update(id, person);
        }
        [HttpPut("Avatar")]
        public ActionResult<Person> PutAvatar([FromQuery] string id, [FromQuery] byte[] value)
        {
            Person person = _repo.Get(id);
            person.ProfilePicture = value;
            return _repo.Update(id, person);
        }
        [HttpDelete]
        public ActionResult Delete([FromQuery] string id)
        {
            try
            {
                _repo.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

    }
}
