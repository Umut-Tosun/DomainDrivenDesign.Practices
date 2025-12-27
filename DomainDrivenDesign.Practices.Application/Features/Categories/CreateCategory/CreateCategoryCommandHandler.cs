using DomainDrivenDesign.Practices.Domain.Abstractions;
using DomainDrivenDesign.Practices.Domain.Categories;
using MediatR;

namespace DomainDrivenDesign.Practices.Application.Features.Categories.CreateCategory;

internal sealed class CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IunitOfWork ıunitOfWork) : IRequestHandler<CreateCategoryCommand>
{
    public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        await categoryRepository.CreateAsync(request.Name, cancellationToken);
        await ıunitOfWork.SaveChangesAsync(cancellationToken);

    }
}



