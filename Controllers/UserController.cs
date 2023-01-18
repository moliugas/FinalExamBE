using FinalExamBE.Database.Entities;
using FinalExamBE.Database.Repository;
using FinalExamBE.DTO;
using FinalExamBE.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FinalExamBE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepo;

        public UserController(IUserRepository repo)
        {
            _userRepo = repo;
        }

        [HttpPost]
        public ActionResult<User> Add([FromBody] UserDTO item)
        {
            try
            {
                User user = _userRepo.Add(new()
                {
                    Username = item.Name,
                    Password = item.Pass,
                    Person = new()
                    {
                        ProfilePicture = Convert.FromBase64String(item.ProfilePicture),
                    }
                });
                return Ok(user);
            }
            catch (FormatException ex)
            {
                return BadRequest("not a base64 string");
            }
        }

        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            try
            {
                List<User> users = _userRepo.Get();
                return Ok(users);
            }
            catch(Exception ex)
            {
                return NoContent();
            }
        }

        [HttpGet("id")]
        public ActionResult<User> Get(string id)
        {
            try
            {
                User users = _userRepo.Get(id);
                return Ok(users);
            }
            catch (Exception ex)
            {
                return NoContent();
            }
        }

        [HttpPut]
        public ActionResult<User> UpdatePassword([FromQuery] string id, [FromQuery] string pass)
        {
            try
            {
                User user = _userRepo.UpdatePassword(id, pass);
                return Ok(user);
            }
            catch (Exception ex) 
            { 
                return NotFound();
            }
            
        }

        [HttpDelete("id")]
        public ActionResult Delete(string id)
        {
            try
            {
                _userRepo.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

    }
}