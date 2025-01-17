using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySpot.Entities;

namespace MySpot.Tests.Unit.Entities
{
    public class WeeklyParkingSpotTests
    {
        [Fact]
        public void givaen_invalid_date_add_reservation_should_fail()
        {
            //ARANGE
            var now = new DateTime(2025,01,17);
            var invalidDate = now.AddDays(7);
            var weeklyParkingSpot = new WeeklyParkingSpot(Guid);
            //ACT


            //ASSERT
        }
    }
}
