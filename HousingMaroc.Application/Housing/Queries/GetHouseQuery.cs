using HousingMaroc.Application.Housing.Models;
using MediatR;

namespace HousingMaroc.Application.Housing.Queries;

public class GetHouseQuery: IRequest<HousingOfferDto>
{
    public int Id { get; set; }
}
