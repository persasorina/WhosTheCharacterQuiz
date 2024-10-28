using WhosTheCharacterQuiz.Domain.Common.Models;
using WhosTheCharacterQuiz.Domain.QuizModels.ValueObjects;

namespace WhosTheCharacterQuiz.Domain.QuizModels.Entities;
public sealed class Question:Entity<QuestionId>
{
    private readonly List<AnswerOption> _answerOptions = new();
    public string Text { get; private set; }
    public string ImageUrl { get; private set; }

    public AnswerOption CorrectAnswer { get; private set; }

    private Question(QuestionId questionId, string text, string imageUrl, AnswerOption correctAnswer, List<AnswerOption> answerOptions):base(questionId)
    {
        Text = text;
        ImageUrl = imageUrl;
        CorrectAnswer = correctAnswer;
        _answerOptions = answerOptions;
    }
    public static Question Create(string text, string imageUrl, AnswerOption correctAnswer, List<AnswerOption> answerOptions)
    {
        return new(QuestionId.CreateUnique(), text, imageUrl, correctAnswer, answerOptions);
    }
    public IReadOnlyList<AnswerOption> AnswerOptions => _answerOptions.AsReadOnly();
}
