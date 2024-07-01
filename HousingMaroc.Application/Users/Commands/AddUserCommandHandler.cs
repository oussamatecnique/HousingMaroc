using HousingMaroc.Application.Common;
using HousingMaroc.Application.Users.Mappers;
using HousingMaroc.Application.Users.Repositories;
using MediatR;

namespace HousingMaroc.Application.Users.Commands;

public class AddUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork) : IRequestHandler<AddUserCommand>
{
    private readonly IUserRepository _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

    public Task Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        _userRepository.Add(request.ToDbUser());
        
        return _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
