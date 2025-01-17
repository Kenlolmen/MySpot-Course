﻿using MySpot.Exceptions;
using MySpot.Services;

namespace MySpot.Entities
{
    public class WeeklyParkingSpot
    {
        private static Clock _clock = new();
        private readonly HashSet<Reservation> _reservations = new();

        public Guid Id { get; }
        public DateTime From { get; }
        public DateTime To { get; }
        public string Name { get; }
        public IEnumerable<Reservation> Reservations => _reservations;



        public WeeklyParkingSpot(Guid id, DateTime from, DateTime to, string name)
        {
            Id = id;
            From = from;
            To = to;
            Name = name;
        }

        public void AddReservation(Reservation reservation)
        {
            var now = _clock.Current.Date;
            var isInvalidDate = reservation.Date.Date < From 
                               || reservation.Date.Date > To 
                               || reservation.Date.Date < now.Date;
            if (isInvalidDate)
            {

                throw new InvalidReservationDateException(reservation.Date);
            }


            var reservationAlreadyExists = _reservations.Any(x =>
                 x.Date.Date == reservation.Date.Date);

            if (reservationAlreadyExists)
            {
                throw new ParkingSpotAlreadyReservedException(Name, reservation.Date);
            }

            _reservations.Add(reservation);
        }

        public void RemoveReservation(Guid reservationId)
            => _reservations.RemoveWhere(x => x.Id == reservationId);
    }
}
