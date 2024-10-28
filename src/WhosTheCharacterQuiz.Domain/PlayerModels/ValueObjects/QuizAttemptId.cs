using WhosTheCharacterQuiz.Domain.Common.Models;
using WhosTheCharacterQuiz.Domain.QuizModels.ValueObjects;

namespace WhosTheCharacterQuiz.Domain.PlayerModels.ValueObjects;

public sealed class QuizAttemptId : ValueObject
{
    public Guid Value { get; private set; }    
    private QuizAttemptId(Guid value)
    {
        Value = value;
    }
    public static QuizAttemptId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
