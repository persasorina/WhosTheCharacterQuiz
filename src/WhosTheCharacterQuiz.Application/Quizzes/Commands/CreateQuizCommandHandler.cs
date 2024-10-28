using ErrorOr;
using MediatR;
using WhosTheCharacterQuiz.Application.Services.Quizzes;
using WhosTheCharacterQuiz.Domain.Common.Errors;
using WhosTheCharacterQuiz.Domain.Persistance;
using WhosTheCharacterQuiz.Domain.Quizzes;

namespace WhosTheCharacterQuiz.Application.Quizzes.Commands;
public sealed class CreateQuizCommandHandler :
    IRequestHandler<CreateQuizCommand, ErrorOr<Quiz>>
{
    private readonly IQuizRepository _quizRepository;
    private readonly IQuizGeneratorService _quizGeneratorService;
    public CreateQuizCommandHandler(
        IQuizRepository quizRepository,
        IQuizGeneratorService quizGeneratorService)
    {
        _quizRepository = quizRepository;
        _quizGeneratorService = quizGeneratorService;
    }
    public async Task<ErrorOr<Quiz>> Handle(CreateQuizCommand command, CancellationToken cancellationToken)
    {
        //check that the name is unique
        if (await _quizRepository.GetQuizByNameAsync(command.Name) is not null)
        {
            return Errors.Quiz.DuplicateQuizName;
        }

        //generate the quiz
        var generateQuizResult = await _quizGeneratorService.GenerateQuizAsync(command);

        if (generateQuizResult.IsError)
        {
            return generateQuizResult.Errors;
        }

        var quiz = generateQuizResult.Value;

        //save to repo
        await _quizRepository.AddAsync(quiz);
        return quiz;
    }    
}
