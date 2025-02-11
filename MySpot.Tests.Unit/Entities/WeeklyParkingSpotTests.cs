using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using MySpot.Entities;
using MySpot.ValueObjects;
using MySpot.Exceptions;
using Shouldly;

namespace MySpot.Tests.Unit.Entities
{
    public class WeeklyParkingSpotTests
    {
        
        [Theory]
        [InlineData("2025-02-01")]
        [InlineData("2025-02-19")]



        public void given_invalid_date_add_reservation_should_fail(string dateString)
        {
            //ARANGE
            var invalidDate = DateTime.Parse(dateString);
            var reservation = new Reservation(Guid.NewGuid(), _weeklyParkingSpot.Id, "John Doe", "XYZ123", new Date(invalidDate));
            //ACT

            var exeption = Record.Exception(() => _weeklyParkingSpot.AddReservation(reservation, _now));

            //ASSERT
            exeption.ShouldNotBeNull();
            exeption.ShouldBeOfType<InvalidReservationDateException>();

        }

        [Fact]
        public void even_reservation_for_already_existing_date_add_reservation_should_fail()
        {
            //ARANGE
            var reservationDate = _now.AddDays(1);
            var reservation = new Reservation(Guid.NewGuid(), _weeklyParkingSpot.Id, "John Doe", "XYZ123", reservationDate);
            var nextReservation = new Reservation(Guid.NewGuid(), _weeklyParkingSpot.Id, "John Doee", "XYZ123", reservationDate);

            _weeklyParkingSpot.AddReservation(reservation, _now);

            //ACT
            var exeption = Record.Exception(() => _weeklyParkingSpot.AddReservation(reservation, reservationDate));


            //ASSERT
            exeption.ShouldNotBeNull();
            exeption.ShouldBeOfType<ParkingSpotAlreadyReservedException>();

        }

        [Fact]
        public void given_date_is_accurate_add_reservation_should_succeed()
        {
            //ARANGE
            var reservationDate = _now.AddDays(1);
            var reservation = new Reservation(Guid.NewGuid(), _weeklyParkingSpot.Id, "John Doe", "XYZ123", reservationDate);
            //ACT
            _weeklyParkingSpot.AddReservation(reservation, _now);
            //ASSERT
            _weeklyParkingSpot.Reservations.ShouldContain(reservation);
        }


        #region Arrange

        private readonly Date _now;
        private readonly WeeklyParkingSpot _weeklyParkingSpot;


        public WeeklyParkingSpotTests()
        {
            _now = new Date(new DateTime(2025, 02, 11));
            _weeklyParkingSpot = new WeeklyParkingSpot(Guid.NewGuid(), new Week(_now), "P1");
        }


        #endregion


    }
}
