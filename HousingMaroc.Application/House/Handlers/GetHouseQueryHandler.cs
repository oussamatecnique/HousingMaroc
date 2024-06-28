using HousingMaroc.Application.Common.Exceptions;
using HousingMaroc.Application.House.Mappers;
using HousingMaroc.Application.House.Queries;
using HousingMaroc.Application.Repositories;
using MediatR;

namespace HousingMaroc.Application.House.Handlers;

public class GetHouseQueryHandler(IHouseRepository houseRepository) : IRequestHandler<GetHouseQuery, HouseDto>
{
    private readonly IHouseRepository _houseRepository = houseRepository ?? throw new ArgumentNullException(nameof(houseRepository));

    public async Task<HouseDto> Handle(GetHouseQuery request, CancellationToken cancellationToken)
    {
        var house = await _houseRepository.GetHouseById(request.Id);
        
        if (house is null)
        {
            throw new NotFoundException("House not found");
        }

        return house.THouseDto();
    }
}
