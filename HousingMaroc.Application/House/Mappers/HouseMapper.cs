namespace HousingMaroc.Application.House.Mappers;

public static class HouseMapper
{
    public static HouseDto THouseDto(this Domain.Models.House house) =>
        new(house.Description, house.Adress, house.City, house.Type);
}
