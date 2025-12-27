using DomainDrivenDesign.Practices.Domain.Products;
using MediatR;

namespace DomainDrivenDesign.Practices.Application.Features.Products.GetAllProduct;

public sealed record GetAllProductQuery() : IRequest<List<Product>>;
