using MySpot.Exceptions;
using MySpot.Services;
using MySpot.ValueObjects;

namespace MySpot.Entities
{
    public class WeeklyParkingSpot
    {
        private static Clock _clock = new();
        private readonly HashSet<Reservation> _reservations = new();

        public Guid Id { get; }
        public Week Week { get; set; }
        public string Name { get; }
        public IEnumerable<Reservation> Reservations => _reservations;



        public WeeklyParkingSpot(Guid id,Week week, string name)
        {
            Id = id;
            Week = week;
            Name = name;
        }

        public void AddReservation(Reservation reservation, Date now)
        {
            
            var isInvalidDate = reservation.Date < Week.From ||
                                reservation.Date > Week.To ||
                                reservation.Date < now;
            if (isInvalidDate)
            {

                throw new InvalidReservationDateException(reservation.Date.Value.Date);
            }


            var reservationAlreadyExists = _reservations.Any(x =>
                 x.Date == reservation.Date);

            if (reservationAlreadyExists)
            {
                throw new ParkingSpotAlreadyReservedException(Name, reservation.Date.Value.Date);
            }

            _reservations.Add(reservation);
        }

        public void RemoveReservation(Guid reservationId)
            => _reservations.RemoveWhere(x => x.Id == reservationId);
    }
}
