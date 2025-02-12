﻿namespace MySpot.Exceptions
{
    public sealed class InvalidReservationDateException : CustomException
    {
        public DateTime Date { get; }
        public InvalidReservationDateException(DateTime date)
            : base($"Reservation date: {date:d} is invalid. ")
        {
            Date = date;
        }


    }


    public sealed class ParkingSpotAlreadyReservedException : CustomException
    {
        public string Name { get; }
        public DateTime Date { get; }
        public ParkingSpotAlreadyReservedException(string name, DateTime date)
            : base($"Parking spot: {name} is already reserved at: {date:d}. ")
        {
            Name = name;
            Date = date;
        }


    }

}
