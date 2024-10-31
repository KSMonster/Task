using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task.Server.Data;
using Task.Server.Models;

namespace Task.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReservationsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Reservation>> CreateReservation(Reservation reservation)
        {
            reservation.UserId = 1;
            reservation.Price = CalculateTotalCost(reservation);

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetReservationById), new { id = reservation.Id }, reservation);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> GetReservationById(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return reservation;
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservationsByUserId(int userId)
        {
            var userReservations = await _context.Reservations
                .Where(r => r.UserId == userId)
                .ToListAsync();

            if (!userReservations.Any())
            {
                return NotFound();
            }

            return Ok(userReservations);
        }

        private decimal CalculateTotalCost(Reservation reservation)
        {
            decimal dailyRate = reservation.Type == "Book" ? 2m : 3m;
            decimal cost = reservation.Days * dailyRate;

            if (reservation.Days > 10)
                cost *= 0.8m;
            else if (reservation.Days > 3)
                cost *= 0.9m;

            cost += 3;
            if (reservation.QuickPickUp)
                cost += 5;

            return cost;
        }
    }
}
