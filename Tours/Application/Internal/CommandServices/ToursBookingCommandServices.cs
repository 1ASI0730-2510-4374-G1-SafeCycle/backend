using backend.Shared.Domain.Repositories;
using backend.Tours.Domain.Model.Aggregates;
using backend.Tours.Domain.Model.Commands;
using backend.Tours.Domain.Repositories;
using backend.Tours.Domain.Services;

namespace backend.Tours.Application.Internal.CommandServices;

public class ToursBookingCommandServices(ITourBookingRepository tourBookingRepository, IUnitOfWork unitOfWork): ITourbookingCommandService
{
 public async Task<TourBooking?> Handle(CreateTourBookingCommand command)
    {
     var tourbooking = new TourBooking(command);
     try
     {
         await tourBookingRepository.AddAsync(tourbooking);
         await unitOfWork.CompleteAsync();
         return tourbooking;
     }
     catch (Exception)
     {
         return null;
     }
    }

    public async Task<TourBooking?> Handle(UpdateTourBookingCommand command)
    {
        var tourbooking = await tourBookingRepository.FindByIdAsync(command.id);
        tourbooking?.UpdateTourBookingFromCommand(command);
        
        await unitOfWork.CompleteAsync();
        return tourbooking;
    }
}