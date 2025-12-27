using DomainDrivenDesign.Practices.Application;
using DomainDrivenDesign.Practices.Infrastructure;
using DomainDrivenDesign.Practices.Domain.Users.Events;
using MediatR;
using Scalar.AspNetCore;
using DomainDrivenDesign.Practices.Infrastructure.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

// ========== TEST BAŞLANGIÇ ==========
Console.WriteLine("\n========== MEDIATR HANDLER TEST ==========");
using (var scope = app.Services.CreateScope())
{
    var handlers = scope.ServiceProvider
        .GetServices<INotificationHandler<UserDomainEvent>>();

    Console.WriteLine($"Kayıtlı UserDomainEvent handler sayısı: {handlers.Count()}");

    if (handlers.Any())
    {
        foreach (var handler in handlers)
        {
            Console.WriteLine($"  ✓ {handler.GetType().FullName}");
        }
    }
    else
    {
        Console.WriteLine("  ✗ HİÇ HANDLER BULUNAMADI!");
    }
}
Console.WriteLine("==========================================\n");
// ========== TEST BİTİŞ ==========

app.MapScalarApiReference();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();