using backend.Renting.Domain.Model.Commands;

namespace backend.Renting.Domain.Model.Aggregates;

public class Rent
{
    public Rent(CreateRentCommand command)
    {
        this.StartTime = command.StartTime;
        this.EndTime = command.EndTime;
        this.PaymentId = command.PaymentId;
        this.UserId = command.UserId;
        this.BikeStationStartId = command.BikeStationStartId;
        this.BikeStationEndId = command.BikeStationEndId;
    }
    
    public int Id { get; private set; }
    public DateTime StartTime { get; private set; }
    public DateTime EndTime { get; private set; }
    public int PaymentId { get; private set; }
    public int UserId { get; private set; }
    public int BikeStationStartId { get; private set; }
    public int BikeStationEndId { get; private set; }

    public Rent()
    {
        Id = -1;
        StartTime = DateTime.MinValue;
        EndTime = DateTime.MinValue;
        PaymentId = -1;
        UserId = -1;
        BikeStationStartId = -1;
        BikeStationEndId = -1;
    }
}