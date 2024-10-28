using WhosTheCharacterQuiz.Domain.Common.Models;

namespace WhosTheCharacterQuiz.Domain.PlayerModels.ValueObjects;
public sealed class PlayerId : ValueObject
{
    public Guid Value { get; private set; }
    private PlayerId(Guid value)
    {
        Value = value;
    }
    public static PlayerId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
