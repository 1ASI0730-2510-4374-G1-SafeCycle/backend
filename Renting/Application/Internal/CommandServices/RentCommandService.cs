using backend.Renting.Domain.Model.Aggregates;
using backend.Renting.Domain.Model.Commands;
using backend.Renting.Domain.Repositories;
using backend.Renting.Domain.Services;
using backend.Shared.Domain.Repositories;

namespace backend.Renting.Application.Internal.CommandServices;

public class RentCommandService(IRentRepository repository, IUnitOfWork unitOfWork) : IRentCommandService
{
    public async Task<Rent?> Handle(CreateRentCommand command)
    {
        var rent = new Rent(command);
        try
        {
            await repository.AddAsync(rent);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }

        return rent;
    }

    public async Task Handle(RemoveRentCommand command)
    {
        var rent = await repository.FindByIdAsync(command.id);
        
        if(rent == null)
            throw new Exception($"Rent with id {command.id} doesnt exists.");
        try
        {
            repository.Remove(rent);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"Rent with id {command.id} doesnt exists.", e);
        }

    }
}