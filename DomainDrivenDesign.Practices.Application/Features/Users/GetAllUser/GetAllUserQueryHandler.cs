using DomainDrivenDesign.Practices.Domain.Users;
using MediatR;

namespace DomainDrivenDesign.Practices.Application.Features.Users.GetAllUser;

public sealed class GetAllUserQueryHandler(IUserRepository userRepository) : IRequestHandler<GetAllUserQuery, List<User>>
{
    public async Task<List<User>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
    {
        var users = await userRepository.GetAllAsync(cancellationToken);
        return users;
    }
}

