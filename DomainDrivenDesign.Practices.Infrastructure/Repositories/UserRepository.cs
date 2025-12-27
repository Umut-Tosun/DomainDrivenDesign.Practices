using DomainDrivenDesign.Practices.Domain.Users;
using DomainDrivenDesign.Practices.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

internal sealed class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext applicationDbContext)
    {
        _context = applicationDbContext;
    }

    public async Task<User> CreateAsync(string username, string email, string password, string country, string city, string street, string postalCode, string fullAddress, CancellationToken cancellationToken = default)
    {
        Console.WriteLine($">>> Context disposed? {_context == null}");

        User user = User.CreateUser(
            name: username,
            email: email,
            password: password,
            country: country,
            city: city,
            street: street,
            postalCode: postalCode,
            fullAddress: fullAddress);

        await _context.users.AddAsync(user, cancellationToken);
        return user;
    }

    public Task<List<User>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return _context.users.ToListAsync(cancellationToken);
    }
}