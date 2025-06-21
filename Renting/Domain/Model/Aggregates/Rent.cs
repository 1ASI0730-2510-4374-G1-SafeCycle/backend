using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using backend.Bikes.Domain.Model.Aggregates;
using backend.IAM.Domain.Model.Aggregates;
using backend.Payment.Domain.Model.Aggregates;
using backend.Renting.Domain.Model.Commands;

namespace backend.Renting.Domain.Model.Aggregates;

public partial class Rent
{
    public Rent(CreateRentCommand command)
    {
        this.StartTime = command.StartTime;
        this.EndTime = command.EndTime;
        this.PaymentId = command.PaymentId;
        this.UserId = command.UserId;
        this.BikeStationId = command.BikeStationId;
 
    }
    
    
    public int Id { get; private set; }
    public DateTime StartTime { get; private set; }
    public DateTime EndTime { get; private set; }
    public int PaymentId { get; private set; }
    public int UserId { get; private set; }
    public int BikeStationId { get; private set; }
  
    
    [Required]
    [ForeignKey("PaymentId")]
    public required Payments payment { get; set; }
    
    [Required]
    [ForeignKey("UserId")]
    public required User user { get; set; }
    
    [Required]
    [ForeignKey("BikeStationId")]
    public required BikeStations bikeStations { get; set; }
    
    public Rent()
    {
        Id = 0;
        StartTime = DateTime.MinValue;
        EndTime = DateTime.MinValue;
        PaymentId = 0;
        UserId = 0;
        BikeStationId = 0;
    }
}