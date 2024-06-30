namespace HousingMaroc.Domain.Models;

public class HousingOffer
{
    public int Id { get; set; }

    public int HouseId { get; set; }
    
    public House House { get; set; }
    
    public decimal Price { get; set; }

    public HousingOfferType HousingOfferType { get; set; }
}

public enum HousingOfferType
{
    Sale,
    RentDaily,
    RentMonthly
}
