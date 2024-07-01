using HousingMaroc.Application.Common.Auth;
using HousingMaroc.Application.Common.Exceptions;
using HousingMaroc.Application.Common.Helpers;
using HousingMaroc.Application.Users.Repositories;
using MediatR;

namespace HousingMaroc.Application.Users.Commands;

public class SignInUserCommandHandler(IJWTHelper jwtHelper, IUserRepository userRepository) : IRequestHandler<SignInUserCommand, string>
{
    private readonly IJWTHelper _jwtHelper = jwtHelper ?? throw new ArgumentNullException(nameof(jwtHelper));
    private readonly IUserRepository _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));

    public async Task<string> Handle(SignInUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByEmailAsync(request.Email);

        if (user == null)
        {
            throw new NotFoundException("User not found");
        }

        if (!request.Password.VerifyPassword(user.Password))
        {
            throw new Exception("Invalid password");
        }

        return _jwtHelper.GenerateJwtToken(user.Id, user.Email, user.UserRole.ToString());
    }
}
