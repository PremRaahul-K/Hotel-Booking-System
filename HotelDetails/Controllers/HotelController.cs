using HotelDetails.Interfaces;
using HotelDetails.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IRepo<int, Hotel> _repo;

        public HotelController(IRepo<int,Hotel> repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public ActionResult<ICollection<Hotel>> GetAll()
        {
            return Ok(_repo.GetAll().ToList());
        }
        [HttpPost]
        public ActionResult<Hotel> Add(Hotel hotel)
        {
            _repo.Add(hotel);
            return Created("Home", hotel);
        }
        [HttpDelete]
        public ActionResult<Hotel> Delete(int id) 
        { 
            var hotel = _repo.Delete(id);
            return Ok(hotel);
        }
        [HttpPut]
        public ActionResult<Hotel> Update(Hotel hotel)
        {
            var updatedHotel = _repo.Update(hotel);
            return Ok(hotel);
        }
    }
}
