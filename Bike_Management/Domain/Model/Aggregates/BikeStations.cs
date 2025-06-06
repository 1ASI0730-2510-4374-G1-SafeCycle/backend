using System.ComponentModel.DataAnnotations;
using backend.Bike_Management.Domain.Model.Commands;

namespace backend.Bike_Management.Domain.Model.Aggregates;

public partial class BikeStations
{
    protected BikeStations()
    {
        name = string.Empty;
        address = string.Empty;
        maxCapacity = 0;
        lat = 0;
        lng = 0;
    }

    public BikeStations(CreateBikeStationCommand command)
    {
        name = command.name;
        address = command.address;
        maxCapacity = command.maxCapacity;
        lat = command.lat;
        lng = command.lng;
    }
    
    public int Id { get; set; }
    
    [Required]
    [StringLength(50,MinimumLength = 1,ErrorMessage = "BikeStation name has to be between 1 and 50 characters")]
    public string name { get; set; }
    
    [StringLength(50,MinimumLength = 1,ErrorMessage = "BikeStation address has to be between 1 and 50 characters")]
    public string address { get; set; }
    
    [Range(1, 1000)]
    public int maxCapacity { get; set; }
    
    [Required]
    public float lat { get; set; }
    
    [Required]
    public float lng { get; set; }

}