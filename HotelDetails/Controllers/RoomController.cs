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
    public class RoomController : ControllerBase
    {
        private readonly IRepo<int, Room> _repo;

        public RoomController(IRepo<int, Room> repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<Room>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ICollection<Room>> GetAll()
        {
            try
            {
                var rooms = _repo.GetAll().ToList();
                return Ok(rooms);
            }
            catch (ArgumentNullException ane)
            {
                return NotFound("No rooms are available at present moment");
            }
        }
        [HttpPost]
        [ProducesResponseType(typeof(Room), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Room> Add(Room room)
        {
            var addedRoom = _repo.Add(room);
            if (addedRoom == null)
            {
                return BadRequest("Unable to add the room");
            }
            return Created("Home", room);
        }
        [HttpDelete]
        [ProducesResponseType(typeof(Room), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Room> Delete(int id)
        {
            var room = _repo.Delete(id);
            if (room != null)
            {
                return Ok(room);
            }
            return BadRequest("Unable to delete the room");
        }
        [HttpPut]
        [ProducesResponseType(typeof(Room), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Room> Update(Room room)
        {
            var updatedHotel = _repo.Update(room);
            if (updatedHotel == null)
            {
                BadRequest("Unable to update room details");
            }
            return Ok(room);
        }
    }
}
