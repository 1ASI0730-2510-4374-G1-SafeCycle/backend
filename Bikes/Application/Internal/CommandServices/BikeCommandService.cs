using backend.Bikes.Domain.Services;
using backend.Bikes.Domain.Model.Aggregates;
using backend.Bikes.Domain.Model.Commands;
using backend.Bikes.Domain.Repositories;
using backend.Shared.Domain.Repositories;

namespace backend.Bikes.Application.Internal.CommandServices;

public class BikeCommandService(IBikesRepository bikesRepository, IBikeStationRepository bikeStationRepository, IUnitOfWork unitOfWork): IBikesCommandService
{
    public async Task<Bike?> Handle(CreateBikeCommand command)
    {
        var station = await bikeStationRepository.FindByIdAsync(command.bikeStationId);
        if (station == null) throw new Exception("Bike station not found");

        var bike = new Bike(command)
        {
            bikeStation = station
        };

        await bikesRepository.AddAsync(bike);
        await unitOfWork.CompleteAsync();

        return bike;
    }

    public async Task<Bike?> Handle(UpdateBikeCommand command)
    {
        var bike = await bikesRepository.FindByIdAsync(command.id);

        bike?.UpdateFromCommand(command);  

        await unitOfWork.CompleteAsync();  
        return bike;
    }
}