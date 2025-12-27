using DomainDrivenDesign.Practices.Domain.Abstractions;
using DomainDrivenDesign.Practices.Domain.Users;
using DomainDrivenDesign.Practices.Domain.Users.Events;
using MediatR;

namespace DomainDrivenDesign.Practices.Application.Features.Users.CreateUser;

internal sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
{
    private readonly IUserRepository userRepository;
    private readonly IunitOfWork unitOfWork;
    private readonly IMediator mediator;

    public CreateUserCommandHandler(IUserRepository userRepository, IunitOfWork unitOfWork, IMediator mediator)
    {
        this.userRepository = userRepository;
        this.unitOfWork = unitOfWork;
        this.mediator = mediator;

    }

    public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {

        try
        {
            var user = await userRepository.CreateAsync(
                request.username,
                request.email,
                request.password,
                request.country,
                request.city,
                request.street,
                request.postalCode,
                request.fullAddress,
                cancellationToken);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            Console.WriteLine($"\n>>> PUBLISH ÖNCESİ - User ID: {user.Id}");
            await mediator.Publish(new UserDomainEvent(user));
            Console.WriteLine($">>> PUBLISH SONRASI\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n❌ HATA: {ex.Message}");
            Console.WriteLine($"Stack: {ex.StackTrace}");
            throw;
        }


    }
}
