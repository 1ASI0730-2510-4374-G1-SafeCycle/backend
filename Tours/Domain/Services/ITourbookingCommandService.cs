using backend.Tours.Domain.Model.Commands;

namespace backend.Tours.Domain.Services;


public interface ITourbookingCommandService
{
    Task<Model.Aggregates.TourBooking?> Handle(CreateTourBookingCommand command);
    
    Task<Model.Aggregates.TourBooking?> Handle(UpdateTourBookingCommand command);
}