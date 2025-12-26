using DomainDrivenDesign.Practices.Domain.Abstractions;
using DomainDrivenDesign.Practices.Domain.Products;

namespace DomainDrivenDesign.Practices.Domain.Categories;

public sealed class Category : Entity
{
    public Category(Guid id) : base(id)
    {
    }

    public string Name { get; set; } = default!;
    public ICollection<Product> Products { get; set; } = new List<Product>();
}
