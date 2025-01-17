namespace MySpot.ValueObjects
{
    public sealed record ParkingSpotName(string Value)
    {
        public string Value { get; } = Value;

        public static implicit operator string(ParkingSpotName name)
            => name.Value;

        public static implicit operator ParkingSpotName(string value)
            => new(value);
    }
}
