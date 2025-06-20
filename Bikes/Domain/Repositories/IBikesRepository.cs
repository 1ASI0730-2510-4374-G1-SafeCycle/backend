﻿using backend.Bikes.Domain.Model.Aggregates;
using backend.Shared.Domain.Repositories;

namespace backend.Bikes.Domain.Repositories;

public interface IBikesRepository : IBaseRepository<Bike>
{
    Task<IEnumerable<Bike>> GetAllBikesAsync();
    
    Task<IEnumerable<Bike>> GetAllAvailableBikesAsync();
    
    Task<Bike?> GetBikeByIdAsync(int id);
}