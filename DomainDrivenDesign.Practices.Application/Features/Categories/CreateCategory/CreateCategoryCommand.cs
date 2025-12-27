using MediatR;

namespace DomainDrivenDesign.Practices.Application.Features.Categories.CreateCategory;

public sealed record CreateCategoryCommand(string Name) : IRequest;

