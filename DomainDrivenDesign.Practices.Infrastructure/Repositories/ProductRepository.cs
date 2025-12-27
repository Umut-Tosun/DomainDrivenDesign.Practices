using DomainDrivenDesign.Practices.Domain.Products;
using DomainDrivenDesign.Practices.Domain.Shared;
using DomainDrivenDesign.Practices.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DomainDrivenDesign.Practices.Infrastructure.Repositories;

internal class ProductRepository(ApplicationDbContext applicationDbContext) : IProductRepository
{
    public async Task CreateAsync(string name, int quantity, decimal amount, string currency, Guid categoryId, CancellationToken cancellationToken = default)
    {
        Product product = new(Guid.NewGuid(), new Name(name),quantity, new Money(amount,Currency.FromCode(currency)), categoryId);
        await applicationDbContext.products.AddAsync(product, cancellationToken);
    }
    public Task<List<Product>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return applicationDbContext.products.ToListAsync(cancellationToken);
    }
}
