using WhosTheCharacterQuiz.Api;
using WhosTheCharacterQuiz.Domain;
using WhosTheCharacterQuiz.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{

    // Add services to the container.    
    builder.Services
    .AddApplication()
    .AddInfrastructure()
    .AddPresentation();    
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
