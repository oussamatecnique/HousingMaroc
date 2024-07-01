using HousingMaroc.Application.Users.Repositories;
using HousingMaroc.Domain.Models;
using HousingMaroc.Infrastructure.Common;

namespace HousingMaroc.Infrastructure.Users.Repositories;

public class UserRepository(ApplicationDbContext applicationDbContext): RepositoryBase<User, int>(applicationDbContext), IUserRepository
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
    public async Task<User?> GetUserByEmailAsync(string requestEmail)
    {
        return await DbSet.FirstOrDefaultAsync(user => user.Email.Equals(requestEmail));
    }
}
