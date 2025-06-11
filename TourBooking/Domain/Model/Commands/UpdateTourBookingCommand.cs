namespace backend.TourBooking.Domain.Model.Commands;

public record UpdateTourBookingCommand(int id, string date, string starthour, string endhour, string station, string tour);