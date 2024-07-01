namespace HousingMaroc.Application.Common.Auth;

public interface IJWTHelper
{
    string GenerateJwtToken(int userId, string email, string role);
}
