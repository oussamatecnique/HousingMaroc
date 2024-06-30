namespace HousingMaroc.Domain.Models;

public class User
{
    public int Id { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string Email { get; set; }

    public string PhoneNumber { get; set; }
    
    public string Password { get; set; }

    public UserRole UserRole { get; set; }
}

public enum UserRole
{
    User,
    Seller,
    Admin
}
