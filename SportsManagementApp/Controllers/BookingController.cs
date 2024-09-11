using BookingApplication.Models;
using BookingApplication.Services;
///using BookingApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookingApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly BookingService _bookingService;

        public BookingController(BookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        public async Task<IActionResult> Book([FromBody] BookingRequest request)
        {
             // Get user ID from identity, fallback to default if not available

            if (await _bookingService.BookAsync(request.UserId, request.BookingTime, request.DurationInHours, request.UserIdList))
            {
                return Ok("Booking successful!");
            }

            return BadRequest("You or your team can't make another booking until 1 minute has passed since the last booking.");
        }
    }

   
}
