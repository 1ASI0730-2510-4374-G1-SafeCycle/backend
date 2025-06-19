using backend.Bikes.Domain.Model.Aggregates;
using backend.Shared.Domain.Repositories;

namespace backend.Bikes.Domain.Repositories;

public interface IBikeStationRepository : IBaseRepository<BikeStations>
{
}