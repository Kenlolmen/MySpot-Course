﻿using MySpot.Models;

namespace MySpot.Services
{
    public class ReservationsService
    {
        private static int _id = 1;
        private static readonly List<Reservation> _reservations = new();

        private static readonly List<string> _parkingSpotNames = new()
        {
            "P1", "P2", "P3", "P4", "P5"
        };


        public Reservation Get(int id)
            => _reservations.SingleOrDefault(x => x.ID == id);

        

        public IEnumerable<Reservation> GetAll()
            => _reservations;


        public int? Create(Reservation reservation)
        {
            if (_parkingSpotNames.All(x => x != reservation.ParkingSpotName))
            {
                return default;
            }
            reservation.Date = DateTime.UtcNow.AddDays(1).Date;

            var reservationAlreadyExists = _reservations.Any(x =>
                 x.ParkingSpotName == reservation.ParkingSpotName &&
                 x.Date.Date == reservation.Date.Date);

            if (reservationAlreadyExists)
            {
                return default;
            }

            reservation.ID = _id;
            _id++;
            _reservations.Add(reservation);

            return reservation.ID;
        }

        public bool Update(int id, Reservation reservation)
        {
            var existingReservation = _reservations.SingleOrDefault(x => x.ID == id);
            if (existingReservation == null)
            {
                return false;
            }

            existingReservation.LicensePlate = reservation.LicensePlate;
            return true;
        }

        public bool Delete(int id)
        {
            var existingReservation = _reservations.SingleOrDefault(x => x.ID == id);
            if (existingReservation == null)
            {
                return false;
            }

            _reservations.Remove(existingReservation);
            return true;
        }
    }
}