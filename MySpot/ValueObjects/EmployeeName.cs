﻿namespace MySpot.ValueObjects
{
    public sealed record EmployeeName(string Value)
    {
        public string Value { get; } = Value;

        public static implicit operator string(EmployeeName name)
            => name.Value;

        public static implicit operator EmployeeName(string value)
            => new(value);
    }
}
