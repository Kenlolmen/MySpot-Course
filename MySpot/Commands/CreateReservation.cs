using MySpot.ValueObjects;

namespace MySpot.Commands
{
    public record CreateReservation(Guid ParkingSpotId, Guid ReservationId,Date date,
        string EmployeeName, string LicensePlate);

}
