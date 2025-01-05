using Microsoft.AspNetCore.Mvc;
using MySpot.Models;

namespace MySpot.Controllers
{
    [ApiController]
    [Route("reservations")]
    public class ResertavionsController : ControllerBase
    {
        private static int _id = 1;
        private static readonly List<Reservation> _reservations = new();

        private static readonly List<string> _parkingSpotNames = new()
        {
            "P1", "P2", "P3", "P4", "P5"
        };

        [HttpGet]
        public ActionResult<IEnumerable<Reservation>> Get() => _reservations;

        [HttpGet("{id:int}")]
        public ActionResult<Reservation> Get(int id)
        {
            var reservation = _reservations.SingleOrDefault(x => x.ID == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return reservation;
        }

        [HttpPost]
        public ActionResult Post(Reservation reservation)
        {
            if (_parkingSpotNames.All(x => x != reservation.ParkingSpotName))
            {
                return BadRequest();
            }
            reservation.Date = DateTime.UtcNow.AddDays(1).Date;

            var reservationAlreadyExists = _reservations.Any(x =>
                 x.ParkingSpotName == reservation.ParkingSpotName &&
                 x.Date.Date == reservation.Date.Date);

            if (reservationAlreadyExists)
            {
                return BadRequest();
            }

            reservation.ID = _id;
            _id++;
            _reservations.Add(reservation);

            return CreatedAtAction(nameof(Get), new { id = reservation.ID }, null);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Reservation reservation)
        {
            var existingReservation = _reservations.SingleOrDefault(x => x.ID == id);
            if (existingReservation == null)
            {
                return NotFound();
            }

            existingReservation.LicensePlate = reservation.LicensePlate;
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var existingReservation = _reservations.SingleOrDefault(x => x.ID == id);
            if (existingReservation == null)
            {
                return NotFound();
            }

            _reservations.Remove(existingReservation);
            return NoContent();
        } 
    }
}
