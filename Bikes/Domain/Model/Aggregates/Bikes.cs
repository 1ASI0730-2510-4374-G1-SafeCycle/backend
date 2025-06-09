using System.ComponentModel.DataAnnotations;
using backend.Bikes.Domain.Model.Commands;


namespace backend.Bikes.Domain.Model.Aggregates;

public partial class BikesManagement
{
    protected BikesManagement()
    {
        condition = string.Empty;
        available = string.Empty;
    }

    public BikesManagement(CreateBikeCommand command)
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
    
    public int bikeStationId { get; set; }
}