﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using backend.Bikes.Domain.Model.Commands;


namespace backend.Bikes.Domain.Model.Aggregates;

public partial class Bike
{
    protected Bike()
    {
        condition = string.Empty;
        available = false;
        BikeStationId = 0;
    }

    public Bike(CreateBikeCommand command)
    {
        condition = command.condition;
        available = command.available;
        BikeStationId = command.bikeStationId;
    }
    
    public int Id { get; set; }
    
    [Required]
    [StringLength(20, MinimumLength = 1)]
    public string condition {get; set;}
    
    [Required]
    [StringLength(5, MinimumLength = 1)]
    public bool available {get; set;}
    
    [Required]
    public int BikeStationId { get; set; } 
    
    [ForeignKey("BikeStationId")]
    [Required]
    public required BikeStations bikeStation { get; set; }
    
    public void UpdateFromCommand(UpdateBikeCommand command)
    {
        condition = command.condition;
        available = command.available;
        BikeStationId = command.bikeStationId;
    }
}