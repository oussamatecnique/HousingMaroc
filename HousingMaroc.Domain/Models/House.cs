namespace HousingMaroc.Domain.Models;

public class House
{
    public int Id { get; set; }

    public string Description { get; set; }

    public string Adress { get; set; }

    public string City { get; set; }

    public HouseType Type { get; set; }
}
