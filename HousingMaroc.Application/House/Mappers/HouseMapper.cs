namespace HousingMaroc.Application.House.Mappers;

public static class HouseMapper
{
    public static HouseDto THouseDto(this Domain.Models.House house) =>
        new(house.Description, house.Address, house.City, house.Type);
}
