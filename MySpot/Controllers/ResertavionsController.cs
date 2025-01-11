using Microsoft.AspNetCore.Mvc;
using MySpot.Entities;
using MySpot.Services;

namespace MySpot.Controllers
{
    [ApiController]
    [Route("reservations")]
    public class ResertavionsController : ControllerBase
    {
        private readonly ReservationsService _service = new();


        [HttpGet]
        public ActionResult<IEnumerable<Reservation>> Get() => Ok(_service.GetAll());

        [HttpGet("{id:int}")]
        public ActionResult<Reservation> Get(int id)
        {
            var reservation = _service.Get(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return Ok(reservation);
        }

        [HttpPost]
        public ActionResult Post(Reservation reservation)
        {
            var id = _service.Create(reservation);
            if(id == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Get), new { id }, null);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Reservation reservation)
        {
            var updated = _service.Update(id, reservation);
            if(updated == false)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
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
