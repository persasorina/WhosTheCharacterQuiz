using Microsoft.AspNetCore.Mvc.Infrastructure;
using WhosTheCharacterQuiz.Api.Common.Errors;
using WhosTheCharacterQuiz.Api.Common.Mapping;

namespace WhosTheCharacterQuiz.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, WhosTheCharacterQuizProblemDetailsFactory>();
        services.AddMappings();
        return services;
    }
}
