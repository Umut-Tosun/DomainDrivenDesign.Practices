using DomainDrivenDesign.Practices.Domain.Users;
using MediatR;

namespace DomainDrivenDesign.Practices.Application.Features.Users.GetAllUser;

public sealed record GetAllUserQuery(): IRequest<List<User>>;

