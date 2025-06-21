using backend.Renting.Domain.Model.Aggregates;
using backend.Renting.Domain.Model.Commands;
using backend.IAM.Domain.Model.Aggregates;
using backend.IAM.Domain.Model.Commands;

namespace backend.Renting.Domain.Services;

public interface IRentCommandService
{
    Task<Rent?> Handle(CreateRentCommand command);
    
}