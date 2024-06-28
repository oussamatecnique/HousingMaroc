using MediatR;

namespace HousingMaroc.Application.House.Queries;

public class GetHouseQuery: IRequest<HouseDto>
{
    public int Id { get; set; }
}
