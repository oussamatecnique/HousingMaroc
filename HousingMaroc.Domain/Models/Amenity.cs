namespace HousingMaroc.Domain.Models;

public class Amenity
{
    public int Id { get; set; }

    public string Name { get; set; }
    
    public ICollection<HouseAmenity> HouseAmenities { get; set; }
}
