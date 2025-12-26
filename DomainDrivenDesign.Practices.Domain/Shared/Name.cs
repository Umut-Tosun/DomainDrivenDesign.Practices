namespace DomainDrivenDesign.Practices.Domain.Shared;

public sealed record Name
{
    public string Value { get; init; }
    public Name(string value)
    {
        if(string.IsNullOrEmpty(value))
            throw new ArgumentException("Name cannot be null or empty.", nameof(value));
        if (value.Length < 3)
            throw new ArgumentException("Name must be at least 2 characters long.", nameof(value));

        Value = value;
    }
}
