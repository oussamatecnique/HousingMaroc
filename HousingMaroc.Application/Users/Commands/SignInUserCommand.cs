using MediatR;

namespace HousingMaroc.Application.Users.Commands;

public record SignInUserCommand(string Email, string Password): IRequest<string>;
