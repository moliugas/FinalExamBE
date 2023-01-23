using FinalExamBE.Database.Entities;
using FinalExamBE.DTO;
using FinalExamBE.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FinalExamBE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : Controller
    {
        private readonly IAddressRepository _repo;

        public AddressController(IAddressRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        [Route("Add")]
        public Address Add([FromBody] AddressDTO item)
        {
            return _repo.Add(new()
            {
                City = item.City,
                StreetName = item.StreetName,
                BuildingNumber = item.BuildingNumber,
                ApartmentNumber = item.ApartmentNumber,
            });
        }

        [HttpPut()]
        public ActionResult<Address> Update([FromQuery] string id, [FromQuery] AddressDTO item)
        {
            Address address = _repo.Get(id);
            address.StreetName = item.StreetName;
            address.BuildingNumber = item.BuildingNumber;
            return _repo.Update(id, address);
        }

        [HttpPut("Name")]
        public ActionResult<Address> PutName([FromQuery] string id, [FromQuery] string value)
        {
            Address address = _repo.Get(id);
            address.ApartmentNumber = value;
            return _repo.Update(id, address);
        }

        [HttpPut("Building")]
        public ActionResult<Address> PutBuilding([FromQuery] string id, [FromQuery] string value)
        {
            Address address = _repo.Get(id);
            address.BuildingNumber = value;
            return _repo.Update(id, address);
        }

        [HttpPut("Email")]
        public ActionResult<Address> PutCity([FromQuery] string id, [FromQuery] string value)
        {
            Address address = _repo.Get(id);
            address.City = value;
            return _repo.Update(id, address);
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
