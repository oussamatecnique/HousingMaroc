namespace HousingMaroc.Domain.Models;

public class HouseBooking
{
    public int Id { get; set; }
    
    public int HouseId { get; set; }
    
    public House House { get; set; }
    
    public DateTime StartDate { get; set; }
    
    public DateTime EndDate { get; set; }
    
    public int UserId { get; set; }
    
    public User User { get; set; }
    
    public decimal TotalPrice { get; set; }
}
