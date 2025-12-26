using DomainDrivenDesign.Practices.Domain.Abstractions;

namespace DomainDrivenDesign.Practices.Domain.Users;

public sealed class User : Entity
{
    public User(Guid id) : base(id)
    {
    }

    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string Country    { get; set; } = default!;
    public string City   { get; set; } = default!;
    public string Street   { get; set; } = default!;
    public string FullAddress   { get; set; } = default!;
    public string PostalCode { get; set; }
 
}
