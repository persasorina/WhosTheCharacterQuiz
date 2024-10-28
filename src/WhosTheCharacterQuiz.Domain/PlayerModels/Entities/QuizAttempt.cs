using WhosTheCharacterQuiz.Domain.Common.Models;
using WhosTheCharacterQuiz.Domain.PlayerModels.ValueObjects;
using WhosTheCharacterQuiz.Domain.QuizModels.ValueObjects;

namespace WhosTheCharacterQuiz.Domain.PlayerModels.Entities;
public sealed class QuizAttempt:Entity<QuizAttemptId>
{
    public QuizId QuizId { get; private set; }

    public decimal? Result { get; private set; }

    public DateTime StartedDateTime { get; private set; }
    public DateTime? CompletedDateTime { get; private set; }

    private QuizAttempt(QuizAttemptId quizAttemptId, QuizId quizId, int result, DateTime startedDateTime, DateTime? completedDateTime):base(quizAttemptId)
    {
        QuizId = quizId;
        Result = result;
        StartedDateTime = startedDateTime;
        CompletedDateTime = completedDateTime;
    }

    public static QuizAttempt Create(QuizId quizId, int result, DateTime startedDateTime, DateTime? completedDateTime)
    {
        return new(QuizAttemptId.CreateUnique(),
            quizId,
            result,
            startedDateTime,
            completedDateTime);
    }
}
