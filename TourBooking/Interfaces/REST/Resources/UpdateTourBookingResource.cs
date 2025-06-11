namespace backend.TourBooking.Interfaces.REST.Resources;

public record UpdateTourBookingResource(int Id, string date, string starthour, string endhour, string station, string tour);