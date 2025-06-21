namespace backend.Bikes.Domain.Model.ValueObjects;

public record Location
{
    public float Latitude { get; }
    public float Longitude { get; }

    public Location(float latitude, float longitude)
    {
        if (latitude < -90 || latitude > 90)
            throw new ArgumentOutOfRangeException(nameof(latitude), "Latitude must be between -90 and 90.");

        if (longitude < -180 || longitude > 180)
            throw new ArgumentOutOfRangeException(nameof(longitude), "Longitude must be between -180 and 180.");

        Latitude = latitude;
        Longitude = longitude;
    }
}