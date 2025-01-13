using MySpot.Entities;
using MySpot.DTO;
using MySpot.Commands;

namespace MySpot.Services
{
    public class ReservationsService
    {
        private static Clock _clock = new();

        private static readonly List<WeeklyParkingSpot> weeklyParkingSpots = new()
        {
            new WeeklyParkingSpot(Guid.Parse("00000000-0000-0000-000000000001"), _clock.Current, _clock.Current.AddDays(7),"P1"),
            new WeeklyParkingSpot(Guid.Parse("00000000-0000-0000-000000000002"), _clock.Current, _clock.Current.AddDays(7),"P2"),
            new WeeklyParkingSpot(Guid.Parse("00000000-0000-0000-000000000003"), _clock.Current, _clock.Current.AddDays(7),"P3"),
            new WeeklyParkingSpot(Guid.Parse("00000000-0000-0000-000000000004"), _clock.Current, _clock.Current.AddDays(7),"P4"),
            new WeeklyParkingSpot(Guid.Parse("00000000-0000-0000-000000000005"), _clock.Current, _clock.Current.AddDays(7),"P5")
        };

        private WeeklyParkingSpot GetWeeklyParkingSpotByReservation(Guid reservationId)
        => weeklyParkingSpots.SingleOrDefault(x => x.Reservations.Any(r => r.Id == reservationId));
        


        public ReservationDto Get(Guid id)
            => GetAllWeekly().SingleOrDefault(x => x.Id == id);



        public IEnumerable<ReservationDto> GetAllWeekly()
            => weeklyParkingSpots.SelectMany(x => x.Reservations)
            .Select(x => new ReservationDto
            {
                Id = x.Id,
                ParkingSpotId = x.ParkingSpotId,
                EmployeeName = x.EmployeeName,
                Date = x.Date
            });


        public Guid? Create(CreateReservation command)
        {
            var weeklyparkingspot = weeklyParkingSpots.SingleOrDefault(x => x.Id == command.ParkingSpotId);
            if (weeklyparkingspot == null)
            {
                return default;
            }

            var reservation = new Reservation(command.ReservationId, command.ParkingSpotId, command.EmployeeName, command.LicensePlate, command.date);
            weeklyparkingspot.AddReservation(reservation);

            return reservation.Id;
        }

        public bool Update(ChangeReservationLicensePlate command)
        {
            var weeklyParkingSpot = GetWeeklyParkingSpotByReservation(command.ReservationId);
            if (weeklyParkingSpot == null)
            {
                return false;
            }

            var existingReservation = weeklyParkingSpot.Reservations.SingleOrDefault(x => x.Id == command.ReservationId);
            if(existingReservation == null)
            {
                return false;
            }

            if(existingReservation.Date <= _clock.Current)
            {
                return false;
            }


            existingReservation.ChangeLicensePlate(command.LicensePlate);

            return true;

        }

        public bool Delete(DeleteReservation command)
        {
            var weeklyParkingSpot = GetWeeklyParkingSpotByReservation(command.ReservationId);
            if(weeklyParkingSpot == null)
            {
                return false;
            }

            var existingReservation = weeklyParkingSpot.Reservations.SingleOrDefault(x => x.Id == command.ReservationId);
            if (existingReservation == null)
            {
                return false;
            }

            weeklyParkingSpot.RemoveReservation(command.ReservationId);
            return true;
        }
    }
}
