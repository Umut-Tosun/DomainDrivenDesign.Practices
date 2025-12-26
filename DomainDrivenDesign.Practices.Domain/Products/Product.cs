using DomainDrivenDesign.Practices.Domain.Abstractions;
using DomainDrivenDesign.Practices.Domain.Categories;

namespace DomainDrivenDesign.Practices.Domain.Products;

public sealed class Product : Entity
{
    public Product(Guid id) : base(id)
    {
    }

    public string Name { get; set; } = default!;
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string CurrencyCode { get; set; } = default!;
    public Guid CategoryId { get; set; }
    public Category Category { get; set; } 
}
