using HousingMaroc.Domain.Models;

namespace HousingMaroc.Application.Housing.Models;

// get columns from house.cs
public record HousingOfferDto(
    string Description,
    string Address,
    string City,
    decimal Price,
    HousingOfferType OfferType,
    HouseType Type,
    IEnumerable<string> ImageUrls,
    IEnumerable<AmenityDto> Amenities,
    int NumberOfRooms,
    int NumberOfBathrooms,
    int SquareFootage,
    decimal Latitude,
    decimal Longitude);

public record AmenityDto(int Id, string Description);
