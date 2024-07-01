using HousingMaroc.Application.Common.Helpers;
using HousingMaroc.Application.Users.Commands;
using HousingMaroc.Domain.Models;

namespace HousingMaroc.Application.Users.Mappers;

public static class UserMapper
{
    public static User ToDbUser(this AddUserCommand addUserDto)
    {
        return new User
        {
            FirstName = addUserDto.FirstName,
            LastName = addUserDto.LastName,
            Email = addUserDto.Email,
            PhoneNumber = addUserDto.PhoneNumber,
            Password = addUserDto.Password.HashPassword(),
            UserRole = addUserDto.UserRole
        };
    }
}
