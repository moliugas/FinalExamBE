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
        private readonly IAddressRepository _addressRepo;

        public AddressController(IAddressRepository repo)
        {
            _addressRepo = repo;
        }

        [HttpPost]
        [Route("Add")]
        public Address Add([FromBody] AddressDTO item)
        {
            return _addressRepo.Add(new()
            {
                City = item.City,
                StreetName = item.StreetName,
                BuildingNumber = item.BuildingNumber,
                ApartmentNumber = item.ApartmentNumber,
            });
        }
    }
}
