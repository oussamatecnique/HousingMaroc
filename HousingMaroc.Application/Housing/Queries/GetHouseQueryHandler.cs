using HousingMaroc.Application.Common.Exceptions;
using HousingMaroc.Application.Housing.Mappers;
using HousingMaroc.Application.Housing.Models;
using HousingMaroc.Application.Housing.Queries;
using HousingMaroc.Application.Repositories;
using MediatR;

namespace HousingMaroc.Application.Housing.Handlers;

public class GetHouseQueryHandler(IHousingRepository housingRepository) : IRequestHandler<GetHouseQuery, HousingOfferDto>
{
    private readonly IHousingRepository _housingRepository = housingRepository ?? throw new ArgumentNullException(nameof(housingRepository));

    public async Task<HousingOfferDto> Handle(GetHouseQuery request, CancellationToken cancellationToken)
    {
        var house = await _housingRepository.GetHouseById(request.Id);
        
        if (house is null)
        {
            throw new NotFoundException("House not found");
        }

        return house.ToHouseDto();
    }
}
