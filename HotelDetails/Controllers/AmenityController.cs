using HotelDetails.Interfaces;
using HotelDetails.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AmenityController : ControllerBase
    {
        private readonly IRepo<int, Amenity> _repo;

        public AmenityController(IRepo<int, Amenity> repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<Amenity>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ICollection<Amenity>> GetAll()
        {
            var amenities = _repo.GetAll().ToList();
            if (amenities == null)
            {
                return NotFound("No amenities are available at present moment");
            }
            return Ok(amenities);
        }
        [HttpPost]
        [ProducesResponseType(typeof(Amenity), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Amenity> Add(Amenity amenity)
        {
            var addedAmenity = _repo.Add(amenity);
            if (addedAmenity == null)
            {
                return BadRequest("Unable to add the amenity");
            }
            return Created("Home", amenity);
        }
        [HttpDelete]
        [ProducesResponseType(typeof(Amenity), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Amenity> Delete(int id)
        {
            var amenity = _repo.Delete(id);
            if (amenity != null)
            {
                return Ok(amenity);
            }
            return BadRequest("Unable to delete the amenity");
        }
        [HttpPut]
        [ProducesResponseType(typeof(Amenity), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Amenity> Update(Amenity amenity)
        {
            var updatedHotel = _repo.Update(amenity);
            if (updatedHotel == null)
            {
                BadRequest("Unable to update amenity details");
            }
            return Ok(amenity);
        }
    }
}
