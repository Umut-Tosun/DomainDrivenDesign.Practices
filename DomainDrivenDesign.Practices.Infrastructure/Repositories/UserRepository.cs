using DomainDrivenDesign.Practices.Domain.Users;
using DomainDrivenDesign.Practices.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DomainDrivenDesign.Practices.Infrastructure.Repositories;

internal sealed class UserRepository(ApplicationDbContext applicationDbContext) : IUserRepository
{
    public async Task<User> CreateAsync(string username, string email,string password, string country, string city, string street, string postalCode, string fullAddress, CancellationToken cancellationToken = default)
    {
        User user = User.CreateUser(
            name: username,
            email: email,
            password: password,
            country: country,
            city: city,
            street: street,
            postalCode: postalCode,
            fullAddress: fullAddress);

        await applicationDbContext.users.AddAsync(user,cancellationToken);

        return user;

    }

    public Task<List<User>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return applicationDbContext.users.ToListAsync(cancellationToken);

    }
}
