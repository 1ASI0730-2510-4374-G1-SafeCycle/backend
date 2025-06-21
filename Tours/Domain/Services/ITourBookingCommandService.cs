using backend.Tours.Domain.Model.Aggregates;
using backend.Tours.Domain.Model.Commands;

namespace backend.Tours.Domain.Services;

public interface ITourBookingCommandService
{
    Task<TourBooking?> Handle(CreateTourBookingCommand command);
}