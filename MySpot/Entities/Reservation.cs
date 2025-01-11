using Microsoft.AspNetCore.Mvc.ModelBinding;
using MySpot.Exceptions;

namespace MySpot.Entities
{
    public class Reservation
    {
        public int ID { get; set; }
        public string EmployeeName { get; private set; } = string.Empty;
        public string LicensePlate { get; private set; } = string.Empty;
        public DateTime Date { get; private set; }


        public Reservation(int id, string employeename, string licenseplate, DateTime date)
        {
            ID = id;
            EmployeeName = employeename;
            LicensePlate = licenseplate;
            Date = date;
        }

        public void ChangeLicensePlate(string licenseplate)
        {
            if(string.IsNullOrWhiteSpace(licenseplate))
            {
                throw new EmptyLicensePlateException();
            }
        }
    }

    
}
