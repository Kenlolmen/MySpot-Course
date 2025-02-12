﻿namespace MySpot.Exceptions
{
    public sealed class InvalidLicensePlateException : CustomException
    {
        public string LicensePlate { get; }
        public InvalidLicensePlateException(string licensePlate)
            : base($"License plate: {licensePlate} is invalid")
        {
            LicensePlate = licensePlate;
        }

    }
}
