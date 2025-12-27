using MediatR;

namespace DomainDrivenDesign.Practices.Application.Features.Users.CreateUser;

public sealed record CreateUserCommand(
    string username,
    string email,
    string country,
    string city,
    string street,
    string postalCode,
    string fullAddress) : IRequest;
