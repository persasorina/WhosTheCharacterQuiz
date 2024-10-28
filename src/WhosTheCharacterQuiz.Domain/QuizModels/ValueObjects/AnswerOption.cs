using WhosTheCharacterQuiz.Domain.Common.Models;

namespace WhosTheCharacterQuiz.Domain.QuizModels.ValueObjects;
public sealed class AnswerOption : ValueObject
{
    public string Answer { get; private set; }

    private AnswerOption(string answer)
    {
        Answer = answer;
    }
    public static AnswerOption CreateNew(string answer)
    {
        return new(answer);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Answer;
    }
}
