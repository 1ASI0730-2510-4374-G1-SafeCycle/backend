using System.ComponentModel.DataAnnotations;
using backend.Bikes.Domain.Model.Commands;


namespace backend.Bikes.Domain.Model.Aggregates;

public partial class Bikes
{
    protected Bikes()
    {
        condition = string.Empty;
        available = string.Empty;
    }

    public Bikes(CreateBikeCommand command)
    {
        condition = command.condition;
        available = command.available;
    }
    
    public int Id { get; set; }
    
    [Required]
    [StringLength(20, MinimumLength = 1)]
    public string condition {get; set;}
    
    [Required]
    [StringLength(5, MinimumLength = 1)]
    public string available {get; set;}
    
    [Required]
    public BikeStations bikeStation { get; set; }
}