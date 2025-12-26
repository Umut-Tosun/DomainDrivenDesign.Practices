namespace DomainDrivenDesign.Practices.Domain.Products;

internal interface IProductRepository
{
    Task CreateAsync(string name,int quantity,decimal amount,string currency,Guid categoryId,CancellationToken cancellationToken = default);

    Task<List<Product>> GetAllAsync(CancellationToken cancellationToken = default);
}
