namespace backend.TourBooking.Interfaces.REST.Resources;

public record CreateTourBookingResource(string date, string starthour, string endhour, string station, string tour);