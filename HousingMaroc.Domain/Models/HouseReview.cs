namespace HousingMaroc.Domain.Models;

public class HouseReview
{
    public int Id { get; set; }
    
    public int HouseId { get; set; }
    
    public House House { get; set; }
    
    public int Rating { get; set; }
    
    public string Comment { get; set; }
    
    public DateTime Date { get; set; }
    
    public int UserId { get; set; }
    
    public User User { get; set; }
}
