using backend.Bikes.Domain.Repositories;
using backend.IAM.Domain.Repositories;
using backend.Payment.Domain.Repositories;
using backend.Renting.Domain.Model.Aggregates;
using backend.Renting.Domain.Model.Commands;
using backend.Renting.Domain.Repositories;
using backend.Renting.Domain.Services;
using backend.Shared.Domain.Repositories;

namespace backend.Renting.Application.Internal.CommandServices;

public class RentCommandService(IRentRepository repository, IPaymentRepository paymentRepository, IUserRepository userRepository, IBikeStationRepository bikeStationRepository,  IUnitOfWork unitOfWork) : IRentCommandService
{
    public async Task<Rent?> Handle(CreateRentCommand command)
    {
        var payment = await paymentRepository.FindByIdAsync(command.PaymentId);
        if (payment == null) throw new Exception("Payment not found");
        
        var user = await userRepository.FindByIdAsync(command.UserId);
        if (user == null) throw new Exception("User not found");

        var bikeStations = await bikeStationRepository.FindByIdAsync(command.BikeStationId);
        if (bikeStations == null) throw new Exception("BikeStation not found");

        var rent = new Rent(command)
        {
            user = user,
            bikeStations = bikeStations,
            payment = payment
        };
        try
        {
            await repository.AddAsync(rent);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception)
        {
            return null;
        }

        return rent;
    }
}