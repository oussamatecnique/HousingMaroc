namespace HousingMaroc.Domain.Models;

public class House
{
    public int Id { get; set; }

    public int OwnerId { get; set; }
    
    public User Owner { get; set; }

    public string Description { get; set; }
    
    public string Address { get; set; }
    
    public decimal Latitude { get; set; }
    
    public decimal Longitude { get; set; }

    public int NumberOfRooms { get; set; }

    public int NumberOfBathrooms { get; set; }

    public int SquareFootage { get; set; }

    public string City { get; set; }

    public HouseType Type { get; set; }
    
    public ICollection<HouseAmenity> HouseAmenities { get; set; }
}
