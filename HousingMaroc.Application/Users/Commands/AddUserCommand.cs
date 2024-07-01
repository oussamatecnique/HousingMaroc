using HousingMaroc.Domain.Models;
using MediatR;

namespace HousingMaroc.Application.Users.Commands;

public record AddUserCommand(
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    string Password,
    UserRole UserRole) : IRequest;
