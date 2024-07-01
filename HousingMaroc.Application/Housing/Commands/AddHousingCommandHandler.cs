using HousingMaroc.Application.Common;
using HousingMaroc.Application.Common.Auth;
using HousingMaroc.Application.Housing.Mappers;
using HousingMaroc.Application.Repositories;
using MediatR;

namespace HousingMaroc.Application.Housing.Commands;

public class AddHousingCommandHandler(IHousingRepository housingRepository, IUnitOfWork unitOfWork, IUserContext userContext) : IRequestHandler<AddHouseCommand>
{
    private readonly IHousingRepository _housingRepository = housingRepository ?? throw new ArgumentNullException(nameof(housingRepository));
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    private readonly IUserContext _userContext = userContext ?? throw new ArgumentNullException(nameof(userContext));

    public Task Handle(AddHouseCommand request, CancellationToken cancellationToken)
    {
        var houseOffer = request.ToHouseOffer();
        
        houseOffer.House.OwnerId = int.Parse(_userContext.UserId);
        
        _housingRepository.AddHouseOffer(houseOffer);
        
        return _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
