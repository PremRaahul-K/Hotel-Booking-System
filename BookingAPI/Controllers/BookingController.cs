using BookingAPI.Interfaces;
using BookingAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IRepo<int, Booking> _repo;

        public BookingController(IRepo<int, Booking> repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<Booking>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ICollection<Booking>> GetAll()
        {
            var bookings = _repo.GetAll().ToList();
            if (bookings == null)
            {
                return NotFound("No bookings are available at present moment");
            }
            return Ok(bookings);
        }
        [HttpPost]
        [ProducesResponseType(typeof(Booking), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Booking> Add(Booking booking)
        {
            var addedBooking = _repo.Add(booking);
            if (addedBooking == null)
            {
                return BadRequest("Unable to add the booking");
            }
            return Created("Home", booking);
        }
        [HttpDelete]
        [ProducesResponseType(typeof(Booking), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Booking> Delete(int id)
        {
            var booking = _repo.Delete(id);
            if (booking != null)
            {
                return Ok(booking);
            }
            return BadRequest("Unable to delete the booking");
        }
        [HttpPut]
        [ProducesResponseType(typeof(Booking), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Booking> Update(Booking booking)
        {
            var updatedBooking = _repo.Update(booking);
            if (updatedBooking == null)
            {
                BadRequest("Unable to update booking details");
            }
            return Ok(booking);
        }
    }
}
