using DomainDrivenDesign.Practices.Domain.Categories;
using DomainDrivenDesign.Practices.Domain.Shared;
using DomainDrivenDesign.Practices.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DomainDrivenDesign.Practices.Infrastructure.Repositories;

internal class CategoryRepository(ApplicationDbContext applicationDbContext) : ICategoryRepository
{
    public async Task CreateAsync(string name, CancellationToken cancellationToken = default)
    {
        Category category = new(Guid.NewGuid(), new Name(name));
        await applicationDbContext.categories.AddAsync(category, cancellationToken);
    }

    public Task<List<Category>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return applicationDbContext.categories.ToListAsync(cancellationToken);
    }
}
