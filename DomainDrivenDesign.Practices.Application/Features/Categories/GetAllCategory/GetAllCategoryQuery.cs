using DomainDrivenDesign.Practices.Domain.Categories;
using MediatR;

namespace DomainDrivenDesign.Practices.Application.Features.Categories.GetAllCategory;

public sealed record GetAllCategoryQuery():IRequest<List<Category>>;    

