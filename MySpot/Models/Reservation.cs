namespace MySpot.Models
{
    public class Reservation
    {
        public int ID { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public string ParkingSpotName { get; set; } = string.Empty;
        public string LicensePlate { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}
