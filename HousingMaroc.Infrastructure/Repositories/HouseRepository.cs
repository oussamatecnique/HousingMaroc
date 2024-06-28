using HousingMaroc.Domain.Models;

namespace HousingMaroc.Infrastructure.Repositories;

public class HouseRepository(ApplicationDbContext context) : IHouseRepository
{
    private readonly ApplicationDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    public async Task<House?> GetHouseById(int id)
    {
        return await _context.Set<House>().FirstOrDefaultAsync(h => h.Id == id);
    }
}
