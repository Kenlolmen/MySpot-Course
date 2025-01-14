using Microsoft.AspNetCore.Mvc;
using MySpot.Entities;
using MySpot.Services;
using MySpot.Commands;
using MySpot.DTO;

namespace MySpot.Controllers
{
    [ApiController]
    [Route("reservations")]
    public class ResertavionsController : ControllerBase
    {
        private readonly ReservationsService _service = new();


        [HttpGet]
        public ActionResult<IEnumerable<ReservationDto>> Get() => Ok(_service.GetAllWeekly());

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
        public ActionResult Put(ChangeReservationLicensePlate command)
        {
            var updated = _service.Update(command);
            if(updated == false)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id:Guid}")]
        public ActionResult Delete(DeleteReservation command)
        {
            var deleted = _service.Delete(command);
            if (deleted == false)
            {
                return NotFound();
            }
            return NoContent();
        } 
    }
}
