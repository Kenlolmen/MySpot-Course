using Microsoft.AspNetCore.Mvc;
using MySpot.Entities;
using MySpot.Services;
using MySpot.Commands;

namespace MySpot.Controllers
{
    [ApiController]
    [Route("reservations")]
    public class ResertavionsController : ControllerBase
    {
        private readonly ReservationsService _service = new();


        [HttpGet]
        public ActionResult<IEnumerable<Reservation>> Get() => Ok(_service.GetAll());

        [HttpGet("{id:Guid}")]
        public ActionResult<Reservation> Get(Guid id)
        {
            var reservation = _service.Get(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return Ok(reservation);
        }

        [HttpPost]
        public ActionResult Post(CreateReservation command)
        {
            var id = _service.Create(command with {ReservationId = Guid.NewGuid()});
            if(id == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Get), new { id }, null);
        }

        [HttpPut("{id:Guid}")]
        public ActionResult Put(int id, Reservation reservation)
        {
            var updated = _service.Update(id, reservation);
            if(updated == false)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id:Guid}")]
        public ActionResult Delete(Guid id)
        {
            var deleted = _service.Delete(id);
            if (deleted == false)
            {
                return NotFound();
            }
            return NoContent();
        } 
    }
}
