using ErrorOr;
using WhosTheCharacterQuiz.Application.Quizzes.Commands;
using WhosTheCharacterQuiz.Application.Services.Characters;
using WhosTheCharacterQuiz.Domain.Common.Constants;
using WhosTheCharacterQuiz.Domain.Common.Errors;
using WhosTheCharacterQuiz.Domain.QuizModels.Entities;
using WhosTheCharacterQuiz.Domain.QuizModels.ValueObjects;

namespace WhosTheCharacterQuiz.Application.Services.Quizzes;
public sealed class QuizGeneratorService : IQuizGeneratorService
{
    private readonly ICharacterRepository _characterRepository;
    private readonly Random _random = new();

    public QuizGeneratorService(ICharacterRepository characterRepository)
    {
        _characterRepository = characterRepository;
    }
    public async Task<ErrorOr<Domain.Quizzes.Quiz>> GenerateQuizAsync(CreateQuizCommand command)
    {
        //retrieve characters
        var getCharactersResult = (await _characterRepository.GetAllCharactersAsync());
        if (getCharactersResult.IsError)
        {
            return getCharactersResult.Errors;
        }

        var characters = getCharactersResult.Value.ToList();

        //perform validation
        if (characters.Count < Constants.Quiz.NumberOfOptions)
        {
            return Errors.Quiz.InsufficientCharacters;
        }
        if (characters.Count < command.NumberOfQuestions)
        {
            return Errors.Quiz.InsufficientCharacters;
        }

        List<Question> questions = GenerateQuestions(command.NumberOfQuestions, characters);
        return Domain.Quizzes.Quiz.Create(command.Name, command.Description, questions);
    }

    private List<Question> GenerateQuestions(int numberOfQuestions, List<Character> characters)
    {
        var usedCharacterIndexes = new HashSet<int>();
        var questions = new List<Question>();
        for (int i = 0; i < numberOfQuestions; i++)
        {
            //pick a random character, but make sure it is not the main character in one of the previous questions
            var nextIndex = GetNextValidCharacterIndex(usedCharacterIndexes, characters.Count);
            var correctCharacterOption = characters[nextIndex];

            //pick NumberOfOptions-1 distinct incorrect character options
            var incorrectCharacterOptions = characters
                    .Where(character => character.Id != correctCharacterOption.Id)
                    .OrderBy(_ => _random.Next()) //shuffle
                    .Take(Constants.Quiz.NumberOfOptions - 1)
                    .ToList();

            //make a list with all options
            var options = new List<Character>(incorrectCharacterOptions);
            options.Add(correctCharacterOption);

            //shuffle's answers
            options = options.OrderBy(option => _random.Next()).ToList();

            //create question
            var question = Question.Create(
                Constants.Quiz.QuestionText,
                correctCharacterOption.ImageUrl,
                AnswerOption.CreateNew(correctCharacterOption.Name),
                options.ConvertAll(option => AnswerOption.CreateNew(option.Name)));
            questions.Add(question);
        }

        return questions;
    }

    private int GetNextValidCharacterIndex(HashSet<int> usedCharacterIndexes, int characterCount)
    {
        var nextIndex = -1;
        var indexFound = false;
        while (!indexFound)
        {
            nextIndex = _random.Next(characterCount);
            if (!usedCharacterIndexes.Contains(nextIndex))
            {
                usedCharacterIndexes.Add(nextIndex);
                indexFound = true;
            }
        }
        return nextIndex;
    }
}
