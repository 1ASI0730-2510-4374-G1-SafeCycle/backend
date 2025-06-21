using System.ComponentModel.DataAnnotations;
using backend.Bikes.Domain.Model.Commands;
using backend.Bikes.Domain.Model.ValueObjects;
using backend.Renting.Domain.Model.Aggregates;

namespace backend.Bikes.Domain.Model.Aggregates;

public partial class BikeStations
{
    protected BikeStations()
    {
        name = string.Empty;
        address = string.Empty;
        maxCapacity = 0;
        Location = new Location(0, 0);
    }

    public BikeStations(CreateBikeStationCommand command)
    {
        name = command.name;
        address = command.address;
        maxCapacity = command.maxCapacity;
        Location = command.location;
    }

    public int Id { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 1)]
    public string name { get; set; }

    [StringLength(50, MinimumLength = 1)]
    public string address { get; set; }

    [Range(1, 1000)]
    public int maxCapacity { get; set; }

    [Required]
    public Location Location { get; set; }
    
    public ICollection<Bike> Bike { get; set; } = new List<Bike>();
    
    public ICollection<Rent> Rents { get; set; } = new List<Rent>();
    public void UpdateFromCommand(UpdateBikeStationCommand command)
    {
        name = command.name;
        address = command.address;
        maxCapacity = command.maxCapacity;
        Location = command.location;
    }
    
}
