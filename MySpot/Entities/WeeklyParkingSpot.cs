namespace MySpot.Entities
{
    public class WeeklyParkingSpot
    {
        private readonly HashSet<Reservation> _reservations = new();

        public Guid ID { get; }
        public DateTime From { get; }
        public DateTime To { get; }
        public string Name { get; }
        public IEnumerable<Reservation> Reservations => _reservations;



        public WeeklyParkingSpot(Guid id, DateTime from, DateTime to, string name)
        {
            ID = id;
            From = from;
            To = to;
            Name = name;
        }

        public void AddReservation(Reservation reservation)
        {
            var now = DateTime.UtcNow.Date;
            var pastDays = now.DayOfWeek is DayOfWeek.Sunday ? 7 : (int)now.DayOfWeek;
            var remainingDays = 7 - pastDays;

            if (reservation.Date.Date < From || reservation.Date.Date > To || reservation.Date.Date < now.Date)
            {

                return default;
            }
        }
    }
}
