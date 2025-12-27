namespace DomainDrivenDesign.Practices.Domain.Orders;


    public sealed record CreateOrderDto(
        Guid ProductId,
        int Quantity,
        decimal Amount,
        string Currency
    );



