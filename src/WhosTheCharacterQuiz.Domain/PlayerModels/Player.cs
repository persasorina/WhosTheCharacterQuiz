using WhosTheCharacterQuiz.Domain.Common.Models;
using WhosTheCharacterQuiz.Domain.PlayerModels.Entities;
using WhosTheCharacterQuiz.Domain.PlayerModels.ValueObjects;

namespace WhosTheCharacterQuiz.Domain.PlayerAggregate;
public sealed class Player : AggregateRoot<PlayerId>
{
    private readonly List<QuizAttempt> _quizAttempts = new();
    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    private Player(PlayerId id,
        string firstName,
        string lastName,
        List<QuizAttempt> quizAttempts) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        _quizAttempts = quizAttempts;
    }

    public static Player Create(
        string firstName, 
        string lastName, 
        List<QuizAttempt> quizAttempts)
    {
        return new(PlayerId.CreateUnique(),
            firstName,
            lastName,
            quizAttempts);
    }
}
