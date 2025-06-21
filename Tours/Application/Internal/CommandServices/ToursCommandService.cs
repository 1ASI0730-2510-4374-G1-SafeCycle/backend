using backend.Shared.Domain.Repositories;
using backend.Tours.Domain.Model.Commands;
using backend.Tours.Domain.Model.Entities;
using backend.Tours.Domain.Repositories;
using backend.Tours.Domain.Services;

namespace backend.Tours.Application.Internal.CommandServices;

public class ToursCommandService(IToursRepository toursRepository, IUnitOfWork unitOfWork ): IToursCommandService
{
    public async Task<Tour?> Handle(CreateToursCommand command)
    {
        var tour = new Tour(command);
        try
        {
            await toursRepository.AddAsync(tour);
            await unitOfWork.CompleteAsync();
            return tour;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<Tour?> Handle(UpdateToursCommand command)
    {
        var tour = await toursRepository.FindByIdAsync(command.id);
        tour?.UpdateFromCommand(command);
        
        await unitOfWork.CompleteAsync();
        return tour;
    }
}