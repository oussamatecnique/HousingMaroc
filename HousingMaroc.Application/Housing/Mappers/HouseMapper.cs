using HousingMaroc.Application.Housing.Commands;
using HousingMaroc.Application.Housing.Models;
using HousingMaroc.Domain.Models;

namespace HousingMaroc.Application.Housing.Mappers;

public static class HouseMapper
{
    public static HousingOfferDto ToHouseDto(this HousingOffer houseOffer) =>
        new(
            houseOffer.House.Description,
            houseOffer.House.Address,
            houseOffer.House.City,
            houseOffer.Price,
            houseOffer.HousingOfferType,
            houseOffer.House.Type,
            houseOffer.House.HouseImages.Select(i => i.ImageUrl),
            houseOffer.House.HouseAmenities.Select(a => new AmenityDto(a.Amenity.Id, a.Amenity.Name)),
            houseOffer.House.NumberOfRooms,
            houseOffer.House.NumberOfBathrooms,
            houseOffer.House.SquareFootage,
            houseOffer.House.Latitude,
            houseOffer.House.Longitude);

    public static HousingOffer ToHouseOffer(this AddHouseCommand addHousingDto) =>

        new()
        {
            House = addHousingDto.ToHouse(),
            Price = addHousingDto.Price,
            HousingOfferType = addHousingDto.OfferType
        };

    private static House ToHouse(this AddHouseCommand addHousingDto) =>
        new()
        {
            OwnerId = 0,
            Description = addHousingDto.Description,
            Address = addHousingDto.Address,
            Latitude = addHousingDto.Latitude,
            Longitude = addHousingDto.Longitude,
            NumberOfRooms = addHousingDto.NumberOfRooms,
            NumberOfBathrooms = addHousingDto.NumberOfBathrooms,
            SquareFootage = addHousingDto.SquareFootage,
            City = addHousingDto.City,
            Type = addHousingDto.Type,
            HouseAmenities = addHousingDto.Amenities.Select(a => new HouseAmenity {AmenityId = a}).ToList()
        };
}
