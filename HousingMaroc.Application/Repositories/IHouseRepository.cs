namespace HousingMaroc.Application.Repositories;

public interface IHouseRepository
{
    Task<Domain.Models.House?> GetHouseById(int id);
}
