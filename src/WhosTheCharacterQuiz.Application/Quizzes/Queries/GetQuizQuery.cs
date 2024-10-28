using ErrorOr;
using MediatR;
using WhosTheCharacterQuiz.Domain.Quizzes;

namespace WhosTheCharacterQuiz.Application.Quizzes.Queries;
public record GetQuizQuery(string Name): IRequest<ErrorOr<Quiz>>;
