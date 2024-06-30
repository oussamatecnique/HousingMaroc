namespace HousingMaroc.Domain.Models;

public class HouseImage
{
    public int Id { get; set; }

    public int HouseId { get; set; }
    
    public House House { get; set; }
    
    public string ImageUrl { get; set; }

    public int Order { get; set; }
}
