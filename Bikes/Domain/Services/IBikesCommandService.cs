using backend.Bikes.Domain.Model.Aggregates;
using backend.Bikes.Domain.Model.Commands;

namespace backend.Bikes.Domain.Services;

public interface IBikesCommandService
{
    Task<Bike?> Handle(CreateBikeCommand command);
    
    Task<Bike?> Handle(UpdateBikeCommand command);
}