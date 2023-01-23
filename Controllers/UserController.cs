using FinalExamBE.Database.Entities;
using FinalExamBE.DTO;
using FinalExamBE.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FinalExamBE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repo;

        public UserController(IUserRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public ActionResult<User> Add([FromBody] UserCreateDTO item)
        {
            if (_repo.Exists(item.Name))
            {
                return BadRequest("Username taken.");
            }

            try
            {
                User user = _repo.Add(new()
                {
                    Username = item.Name,
                    Password = item.Pass,
                    Person = new()
                    {
                        ProfilePicture = Convert.FromBase64String(item.ProfilePicture.Split(',')[1]),
                    }
                });

                string id = user.Id.ToString();
                HttpContext.Session.SetString("id", id);
                return Ok(user);
            }
            catch (FormatException)
            {
                return BadRequest("not a base64 string");
            }
        }

        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            try
            {
                List<User> items = _repo.Get();
                return Ok(items);
            }
            catch (Exception)
            {
                return NoContent();
            }
        }

        [HttpGet("id")]
        public ActionResult<User> Get(string id)
        {
            try
            {
                User item = _repo.Get(id);
                return Ok(item);
            }
            catch (Exception)
            {
                return NoContent();
            }
        }

        [HttpPut]
        public ActionResult<User> UpdatePassword([FromQuery] string id, [FromQuery] string pass)
        {
            try
            {
                User item = _repo.UpdatePassword(id, pass);
                return Ok(item);
            }
            catch (Exception)
            {
                return NotFound();
            }

        }

        [HttpDelete("id")]
        public ActionResult Delete(string id)
        {
            try
            {
                _repo.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] UserLoginDTO user)
        {
            User? userObj = _repo.Login(user.Name, user.Pass);

            if (userObj != null)
            {
                HttpContext.Session.SetString("id", userObj.Id.ToString());
                return Ok(userObj);
            }
            return NotFound();
        }

        [HttpPost("logout")]
        public ActionResult Logout()
        {
            HttpContext.Session.SetString("id", "");
            return Ok();
        }
    }
}