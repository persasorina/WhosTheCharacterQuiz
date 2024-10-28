using ErrorOr;
using MediatR;
using WhosTheCharacterQuiz.Domain.Quizzes;

namespace WhosTheCharacterQuiz.Application.Quizzes.Commands;
public record CreateQuizCommand(
    string Name,
    string Description,
    int NumberOfQuestions):IRequest<ErrorOr<Quiz>>;

