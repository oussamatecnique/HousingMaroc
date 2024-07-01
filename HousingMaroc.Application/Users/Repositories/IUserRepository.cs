using HousingMaroc.Application.Common;
using HousingMaroc.Domain.Models;

namespace HousingMaroc.Application.Users.Repositories;

public interface IUserRepository: IRepositoryBase<User, int>
{
    Task<User?> GetUserByEmailAsync(string requestEmail);
}
