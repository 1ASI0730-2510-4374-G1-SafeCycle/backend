﻿namespace backend.Bikes.Domain.Model.Commands;

public record CreateBikeCommand(string condition, bool available, int bikeStationId); 