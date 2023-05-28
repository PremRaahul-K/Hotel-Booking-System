using HotelDetails.Interfaces;
using HotelDetails.Models;
using HotelDetails.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IRepo<int, Hotel> _repo;
        private readonly HotelService _service;

        public HotelController(IRepo<int,Hotel> repo,HotelService service)
        {
            _repo = repo;
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ICollection<Hotel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ICollection<Hotel>> GetAll()
        {
            try
            {
                var hotels = _repo.GetAll().ToList();
                return Ok(hotels);
            }
            catch (ArgumentNullException ane)
            {
                return NotFound("No hotels are available at present moment");
            }
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ProducesResponseType(typeof(Hotel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Hotel> Add(Hotel hotel)
        {
            var addedHotel = _repo.Add(hotel);
            if (addedHotel==null)
            {
                return BadRequest("Unable to add the hotel");
            }
            return Created("Home", hotel);
        }
        [HttpDelete]
        [ProducesResponseType(typeof(Hotel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Hotel> Delete(int id) 
        { 
            var hotel = _repo.Delete(id);
            if(hotel != null)
            {
                return Ok(hotel);
            }
            return BadRequest("Unable to delete the hotel");
        }

        [HttpPut]
        [ProducesResponseType(typeof(Hotel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Hotel> Update(Hotel hotel)
        {
            var updatedHotel = _repo.Update(hotel);
            if(updatedHotel == null)
            {
                BadRequest("Unable to update hotel details");
            }
            return Ok(hotel);
        }
        [HttpGet("GetByLocation")]
        [ProducesResponseType(typeof(ICollection<Hotel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ICollection<Hotel>> GetByLocation(string location)
        {
            var hotels = _service.GetHotelsByLocation(location);
            if (hotels == null)
            {
                return NotFound("No hotels are available at present moment");
            }
            return Ok(hotels);
        }
        [HttpGet("GetByPriceRange")]
        [ProducesResponseType(typeof(ICollection<Hotel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ICollection<Hotel>> GetByPriceRange(int min,int max)
        {
            try
            {
                var hotels = _service.GetHotelsByPrice(min, max).ToList();
                return Ok(hotels);
            }
            catch (ArgumentNullException ane)
            {
                return NotFound("No hotels are available at present moment");
            }
        }
        [HttpGet("GetByAmenities")]
        [ProducesResponseType(typeof(ICollection<Hotel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ICollection<Hotel>> GetByAmenities(string amenity)
        {
            try
            {
                var hotels = _service.GetHotelsByAmenity(amenity).ToList();
                return Ok(hotels);

            }
            catch (ArgumentNullException ane)
            {
                return NotFound("No hotels are available at present moment");

            }
        }
    }
}
