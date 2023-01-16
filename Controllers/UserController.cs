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
        private readonly IUserRepository _userRepo;

        public UserController(IUserRepository repo)
        {
            _userRepo = repo;
        }

        [HttpPost]
        [Route("Add")]
        public User Add([FromBody] UserDTO item)
        {
            return _userRepo.Add(new()
            {
                Username = item.Name,
                Password = item.Pass
            });
        }


    }
}