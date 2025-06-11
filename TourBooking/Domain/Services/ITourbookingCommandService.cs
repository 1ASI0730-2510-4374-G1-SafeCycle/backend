using backend.TourBooking.Domain.Model.Commands;

namespace backend.TourBooking.Domain.Services;


public interface ITourbookingCommandService
{
    Task<Model.Aggregates.TourBooking?> Handle(CreateTourBookingCommand command);
    
    Task<Model.Aggregates.TourBooking?> Handle(UpdateTourBookingCommand command);
}