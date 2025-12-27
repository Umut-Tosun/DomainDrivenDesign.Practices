using DomainDrivenDesign.Practices.Domain.Abstractions;
using DomainDrivenDesign.Practices.Domain.Shared;

namespace DomainDrivenDesign.Practices.Domain.Users;

public sealed class User : Entity
{
    private User(Guid Id, Name name, Email email, Password password, Address address) : base(Id)
    {
        Name = name;
        Email = email;
        Password = password;
        Address = address;
    }

    public Name Name { get; set; } = default!;
    public Email Email { get; set; } = default!;
    public Password Password { get; set; } = default!;
    public Address Address { get; set; } = default!;

    public static User CreateUser(string name, string email, string password, string country, string city, string street, string postalCode, string fullAddress)
    {
       
        User user = new(
            Id: Guid.NewGuid(),
            name: new(name),
            email: new(email),
            password: new(password),
            address: new(country, city, street, fullAddress, postalCode));

        return user;

    }
    public void ChangeName(string name)
    {
        Name = new Name(name);
    }
    public void ChangeEmail(string email)
    {
        Email = new Email(email);
    }
    public void ChangePassword(string password)
    {
        Password = new Password(password);
    }
    public void ChangeAddress(string country,string city,string street,string postalCode,string fullAddress)
    {
        Address = new Address(country, city, street, fullAddress, postalCode);
    }

}
