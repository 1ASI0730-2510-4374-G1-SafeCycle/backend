using backend.Renting.Domain.Repositories;
using backend.Shared.Domain.Repositories;
using backend.Tours.Domain.Model.Aggregates;
using backend.Tours.Domain.Model.Commands;
using backend.Tours.Domain.Repositories;
using backend.Tours.Domain.Services;

namespace backend.Tours.Application.Internal.CommandServices;

public class TourBookingCommandService(ITourBookingRepository tourBookingRepository, IToursRepository toursRepository, IRentRepository rentRepository, IUnitOfWork unitOfWork): ITourBookingCommandService
{
    public async Task<TourBooking?> Handle(CreateTourBookingCommand command)
    {
        var tour = await toursRepository.FindByIdAsync(command.tourId);
        if (tour == null) throw new Exception("Tour not found");
        
        var rent = await rentRepository.FindByIdAsync(command.rentId);
        if (rent == null) throw new Exception("Tour not found");

        var booking = new TourBooking(command)
        {
            tour = tour,
            rent = rent
        };
        {
            await tourBookingRepository.AddAsync(booking);
            await unitOfWork.CompleteAsync();
            
            return booking;
        }
    }
}