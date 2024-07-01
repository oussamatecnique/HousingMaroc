using HousingMaroc.Domain.Models;

namespace HousingMaroc.Application.Repositories;

public interface IHousingRepository
{
    Task<HousingOffer?> GetHouseById(int id);
    
    void AddHouseOffer(HousingOffer houseOffer);
}
