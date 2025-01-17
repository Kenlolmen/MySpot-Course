namespace MySpot.ValueObjects
{
    public sealed record ReservationId
    {
        public Guid Value { get; }

        public ReservationId(Guid value)
        {

            Value = value;
        }

        public static ReservationId Create() => new(Guid.NewGuid());

        public static implicit operator Guid(ReservationId date)
            => date.Value;

        public static implicit operator ReservationId(Guid value)
            => new(value);
    }
}
