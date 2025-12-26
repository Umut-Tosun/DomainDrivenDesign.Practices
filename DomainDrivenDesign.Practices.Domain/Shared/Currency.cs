using System.Diagnostics.Tracing;

namespace DomainDrivenDesign.Practices.Domain.Shared;

public sealed record Currency
{
    internal static readonly Currency None = new("");
    public static readonly Currency USD = new("USD");  
    public static readonly Currency EUR = new("EUR");
    public static readonly Currency TRY = new("TRY");
    public string Code { get; init; }
    private Currency(string code)
    {
        Code = code;
    }
    public static Currency FromCode(string code)
    {
        if (string.IsNullOrEmpty(code))
            throw new ArgumentException("Currency code cannot be null or empty.", nameof(code));


        return code.ToUpper() switch
        {
            "USD" => USD,
            "EUR" => EUR,
            "TRY" => TRY,
            _ => throw new ArgumentException($"Unsupported currency code: {code}", nameof(code))
        };

    }
    public static readonly IReadOnlyCollection<Currency> AllCurrencies = new[] {USD,EUR,TRY };




}
