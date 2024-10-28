using ErrorOr;
using WhosTheCharacterQuiz.Application.Quizzes.Commands;

namespace WhosTheCharacterQuiz.Application.Services.Quizzes;
public interface IQuizGeneratorService
{
    Task<ErrorOr<Domain.Quizzes.Quiz>> GenerateQuizAsync(CreateQuizCommand command);
}
