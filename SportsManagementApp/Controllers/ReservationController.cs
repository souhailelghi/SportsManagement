//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using SportsManagementApp.Interfaces;
//using SportsManagementApp.Models;

//namespace SportsManagementApp.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ReservationController : ControllerBase
//    {
//        private readonly IReservationService _reservationService;

//        public ReservationController(IReservationService reservationService)
//        {
//            _reservationService = reservationService;
//        }

//        [HttpPost("create")]
//        public async Task<IActionResult> CreateReservation([FromBody] Reservation reservation)
//        {
//            try
//            {
//                var createdReservation = await _reservationService.CreateReservationAsync(reservation);
//                return Ok(createdReservation);
//            }
//            catch (InvalidOperationException ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }

//        [HttpGet("canreserve")]
//        public async Task<IActionResult> CanReserve(int userId, string fieldType, string part)
//        {
//            var canReserve = await _reservationService.CanReserveAsync(userId, fieldType, part);
//            return Ok(canReserve);
//        }
//    }
//}
