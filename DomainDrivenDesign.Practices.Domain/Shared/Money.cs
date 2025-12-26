namespace DomainDrivenDesign.Practices.Domain.Shared;

public sealed record Money(decimal Amount,Currency Currency)
{
    public static Money operator +(Money a, Money b)
    {
        if (a.Currency.Code != b.Currency.Code)
            throw new InvalidOperationException("Cannot add money with different currencies.");
        return new Money(a.Amount + b.Amount, a.Currency);
    }
    public static Money Zero() => new(0, Currency.None);
    public static Money Zero(Currency currency) => new Money(0, currency);  
    public bool IsZero() => Amount == 0;

}