using DomainDrivenDesign.Practices.Domain.Abstractions;
using DomainDrivenDesign.Practices.Domain.Categories;
using DomainDrivenDesign.Practices.Domain.Shared;

namespace DomainDrivenDesign.Practices.Domain.Products;

public sealed class Product : Entity
{
    public Product(Guid Id,Name name, int quantity, Money price, Guid categoryId) : base(Id)
    {
        CategoryId = categoryId;
        Name = name;
        Quantity = quantity;
        Price = price;
        CategoryId = categoryId;
    }

    public Name Name { get;private set; } = default!;
    public int Quantity { get;private set; }
    public Money Price { get;private set; }
    public Guid CategoryId { get;private set; }
    public Category Category { get;private set; } 
    public void Update(string name,int quantity,decimal amount, string currency, Guid categoryId)
    {
        Name = new Name(name);
        Quantity = quantity;
        Price = new Money(amount, Currency.FromCode(currency));
        CategoryId = categoryId;

    }
}
