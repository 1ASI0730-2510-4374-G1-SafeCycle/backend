namespace backend.Tours.Domain.Model.Commands;

public record CreateTourBookingCommand(string date, string starthour, string endhour, string station, string tour);