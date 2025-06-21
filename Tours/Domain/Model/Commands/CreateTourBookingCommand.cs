namespace backend.Tours.Domain.Model.Commands;

public record CreateTourBookingCommand(int rentId, int tourId);
