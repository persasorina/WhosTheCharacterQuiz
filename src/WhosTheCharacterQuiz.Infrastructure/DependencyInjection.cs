using Microsoft.Extensions.DependencyInjection;
using WhosTheCharacterQuiz.Application.Services.Characters;
using WhosTheCharacterQuiz.Domain.Persistance;
using WhosTheCharacterQuiz.Infrastructure.Persistance.Characters;
using WhosTheCharacterQuiz.Infrastructure.Persistance.Quizzes;

namespace WhosTheCharacterQuiz.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IQuizRepository, QuizRepository>();
        services.AddScoped<ICharacterRepository, CharacterRepository>();

        services
            .AddRickAndMortyClient()
            .ConfigureHttpClient(client => client.BaseAddress = new Uri("https://rickandmortyapi.com/graphql"));
        return services;
    }
}
