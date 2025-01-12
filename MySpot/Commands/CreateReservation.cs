namespace MySpot.Commands
{
    public record CreateReservation(Guid ParkingSpotId, Guid ReservationId,DateTime date,
        string EmployeeName, string LicensePlate);

}
