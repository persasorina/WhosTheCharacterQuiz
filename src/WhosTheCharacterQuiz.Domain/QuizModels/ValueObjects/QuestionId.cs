using WhosTheCharacterQuiz.Domain.Common.Models;

namespace WhosTheCharacterQuiz.Domain.QuizModels.ValueObjects;
public sealed class QuestionId : ValueObject
{
    public Guid Value { get; }

    private QuestionId(Guid value)
    {
        Value = value;
    }

    public static QuestionId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
