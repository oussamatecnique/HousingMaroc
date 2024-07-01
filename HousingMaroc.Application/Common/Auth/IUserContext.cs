namespace HousingMaroc.Application.Common.Auth;

public interface IUserContext
{
    string UserId { get; }
    
    string Email { get; }
}
