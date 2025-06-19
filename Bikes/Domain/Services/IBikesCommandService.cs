using backend.Bikes.Domain.Model.Aggregates;
using backend.Bikes.Domain.Model.Commands;

namespace backend.Bike_Management.Domain.Services;

public interface IBikesCommandService
{
    Task<Bikes.Domain.Model.Aggregates.Bikes?> Handle(CreateBikeCommand command);
}