namespace backend.TourBooking.Interfaces.REST.Resources;

public record TourBookingResource(int Id, string date, string starthour, string endhour, string station, string tour);