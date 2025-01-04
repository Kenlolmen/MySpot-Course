using Microsoft.AspNetCore.Mvc;
using MySpot.Models;

namespace MySpot.Controllers
{
    [ApiController]
    [Route("reservations")]
    public class ResertavionsController : ControllerBase
    {
        private int _id = 1;
        private readonly List<Reservation> _reservations = new();

        private readonly List<string> _parkingSpotNames = new()
        {
            "P1", "P2", "P3", "P4", "P5"
        };

        [HttpGet]
        public void Get()
        {

        }

        [HttpPost]
        public void Post(Reservation reservation)
        {
            if(_parkingSpotNames.All(x => x != reservation.ParkingSpotName))
            {
                return;
            }
        }
    }
}
