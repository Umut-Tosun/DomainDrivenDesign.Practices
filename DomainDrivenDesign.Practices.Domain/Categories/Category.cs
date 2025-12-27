using DomainDrivenDesign.Practices.Domain.Abstractions;
using DomainDrivenDesign.Practices.Domain.Products;
using DomainDrivenDesign.Practices.Domain.Shared;

namespace DomainDrivenDesign.Practices.Domain.Categories;

public sealed class Category : Entity
{
    public Category(Guid id) : base(id)
    {
    }

    public Category(Guid id, Name name) : base(id)
    {
        Name = name;
    }


    public Name Name { get; set; } = default!;
    public ICollection<Product> Products { get;private set; } = new List<Product>();
    public void ChangeName(string name)
    {
        Name = new Name(name);
    }
}
