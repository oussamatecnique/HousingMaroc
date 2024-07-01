using HousingMaroc.Domain.Models;
using MediatR;

namespace HousingMaroc.Application.Housing.Commands;

public record AddHouseCommand: IRequest
{
    public string Description { get; set; }
    
    public string Address { get; set; }
    
    public string City { get; set; }
    
    public decimal Price { get; set; }
    
    public HouseType Type { get; set; }
    
    public IEnumerable<int> Amenities { get; set; }
    
    public int NumberOfRooms { get; set; }
    
    public int NumberOfBathrooms { get; set; }
    
    public int SquareFootage { get; set; }
    
    public decimal Latitude { get; set; }
    
    public decimal Longitude { get; set; }
    
    public IEnumerable<string> Images { get; set; }

    public HousingOfferType OfferType { get; set; }

    public int? OwnerId { get; set; }
}
