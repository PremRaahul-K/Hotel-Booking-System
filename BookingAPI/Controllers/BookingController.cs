using BookingAPI.Interfaces;
using BookingAPI.Models;
using BookingAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookingController : ControllerBase
    {
        private readonly IRepo<int, Booking> _repo;
        private readonly BookingService _bookingService;

        public BookingController(IRepo<int, Booking> repo,BookingService bookingService)
        {
            _repo = repo;
            _bookingService = bookingService;
        }
        [Authorize(Roles = "admin")]
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
        [Authorize(Roles = "user")]
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
        [Authorize(Roles = "admin")]
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
        [Authorize(Roles = "admin")]
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
        [Authorize(Roles = "user")]
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<Booking>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ICollection<Booking>> GetBookingsByUserName(string userName)
        {
            var bookings = _bookingService.GetBookingsByUsername(userName);
            if (bookings == null)
            {
                return NotFound("No bookings are available at present moment");
            }
            return Ok(bookings);
        }
    }
}
