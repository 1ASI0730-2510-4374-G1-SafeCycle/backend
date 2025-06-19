using backend.Bikes.Domain.Model.Aggregates;
using backend.Bikes.Domain.Model.Commands;
using backend.Bikes.Domain.Repositories;
using backend.Bikes.Domain.Services;
using backend.Shared.Domain.Repositories;

namespace backend.Bikes.Application.Internal.CommandServices;

public class BikeStationCommandService(IBikeStationRepository bikeStationRepository, IUnitOfWork unitOfWork): IBikeStationCommandService
{
    public async Task<BikeStations?> Handle(CreateBikeStationCommand command)
    {
        var station = new BikeStations(command); 
        try
        {
            await bikeStationRepository.AddAsync(station);
            await unitOfWork.CompleteAsync();
            return station;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<BikeStations?> Handle(UpdateBikeStationCommand command)
    {
        var station = await bikeStationRepository.FindByIdAsync(command.id);

        station.UpdateFromCommand(command);  

        await unitOfWork.CompleteAsync();  
        return station;
    }
}