using Microsoft.AspNetCore.Mvc.ModelBinding;
using MySpot.Exceptions;
using MySpot.ValueObjects;

namespace MySpot.Entities
{
    public class Reservation
    {
        public Guid Id { get; set; }
        public Guid ParkingSpotId { get; set; }
        public string EmployeeName { get; private set; } = string.Empty;
        public LicensePlate LicensePlate { get; private set; }
        public DateTime Date { get; private set; }


        public Reservation(Guid id, Guid parkingSpotId, string employeename, LicensePlate licenseplate, DateTime date)
        {
            Id = id;
            parkingSpotId = ParkingSpotId;
            EmployeeName = employeename;
            LicensePlate = licenseplate;
            Date = date;
        }

        public void ChangeLicensePlate(LicensePlate licenseplate)
        {
            if(string.IsNullOrWhiteSpace(licenseplate))
            {
                throw new EmptyLicensePlateException();
            }
        }
    }

    
}
