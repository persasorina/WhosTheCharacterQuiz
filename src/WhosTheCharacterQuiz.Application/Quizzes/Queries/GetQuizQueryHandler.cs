using ErrorOr;
using MediatR;
using WhosTheCharacterQuiz.Domain.Persistance;
using WhosTheCharacterQuiz.Domain.Quizzes;

namespace WhosTheCharacterQuiz.Application.Quizzes.Queries;
public sealed class GetQuizQueryHandler : IRequestHandler<GetQuizQuery, ErrorOr<Quiz>>
{
    private readonly IQuizRepository _quizRepository;
    public GetQuizQueryHandler(IQuizRepository quizRepository)
    {
        _quizRepository = quizRepository;
    }
    public async Task<ErrorOr<Quiz>> Handle(GetQuizQuery request, CancellationToken cancellationToken)
    {
        var getResult = await _quizRepository.GetQuizByNameAsync(request.Name);
        if (getResult is null)
        {
            return Error.NotFound();
        }        
        return getResult;
    }
}
