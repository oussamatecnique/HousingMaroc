namespace HousingMaroc.Application.Common.Helpers;

public static class PasswordHashHelper
{
    public static string HashPassword(this string password)
    {
        var salt = BCrypt.Net.BCrypt.GenerateSalt();
        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);

        return hashedPassword;
    }

    public static bool VerifyPassword(this string password, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}
