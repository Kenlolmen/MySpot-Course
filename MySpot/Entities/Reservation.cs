using Microsoft.AspNetCore.Mvc.ModelBinding;
using MySpot.Exceptions;
using MySpot.ValueObjects;

namespace MySpot.Entities
{
    public class Reservation
    {
        public Guid Id { get; set; }
        public ParkingSpotId ParkingSpotId { get; set; }
        public EmployeeName EmployeeName { get; private set; } = string.Empty;
        public LicensePlate LicensePlate { get; private set; }
        public Date Date { get; private set; }


        public Reservation(Guid id, ParkingSpotId parkingSpotId, EmployeeName employeename, LicensePlate licenseplate, Date date)
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
