using backend.Bikes.Domain.Model.Aggregates;
using backend.Bikes.Domain.Repositories;
using backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace backend.Bikes.Infrastructure.Repositories;

public class BikeStationsRepository(SafecycleDBContext context) : BaseRepository<BikeStations>(context), IBikeStationRepository
{
    
}