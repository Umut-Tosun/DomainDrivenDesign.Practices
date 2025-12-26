namespace DomainDrivenDesign.Practices.Domain.Users;

public sealed record Email
{
    public string Value { get; init; }
    public Email(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new ArgumentException("Email cannot be null or empty.", nameof(value));

        if (!value.Contains("@"))
            throw new ArgumentException("Email must contain '@' symbol.", nameof(value));

        Value = value;
    }
}
