using HousingMaroc.Domain.Models;

namespace HousingMaroc.Application;

// get columns from house.cs
public record HouseDto(string Description, string Adress, string City, HouseType Type);
