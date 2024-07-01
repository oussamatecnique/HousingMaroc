using HousingMaroc.Domain.Models;
using HousingMaroc.Infrastructure.Common;

namespace HousingMaroc.Infrastructure.Housing.Repositories;

public class HousingRepository(ApplicationDbContext context) : RepositoryBase<HousingOffer, int>(context), IHousingRepository 
{
    private readonly ApplicationDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    public async Task<HousingOffer?> GetHouseById(int id)
    {
        return await DbSet
            .Include(x => x.House)
            .ThenInclude(x => x.HouseAmenities)
            .ThenInclude(x => x.Amenity)
            .FirstOrDefaultAsync(h => h.Id == id);
    }

    public void AddHouseOffer(HousingOffer houseOffer)
    {
        DbSet.Add(houseOffer);
    }
}
