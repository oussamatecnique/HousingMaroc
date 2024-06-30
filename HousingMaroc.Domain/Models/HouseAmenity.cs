namespace HousingMaroc.Domain.Models;

public class HouseAmenity
{
    public int HouseId { get; set; }
    
    public House House { get; set; }
    
    public int AmenityId { get; set; }
    
    public Amenity Amenity { get; set; }
}
