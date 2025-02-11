using MySpot.ValueObjects;

namespace MySpot.DTO
{
    public class ReservationDto
    {
        public Guid Id { get; set; }
        public ParkingSpotId ParkingSpotId { get; set; }
        public EmployeeName EmployeeName { get; set; }
        public Date Date { get; set; }
    }

}
