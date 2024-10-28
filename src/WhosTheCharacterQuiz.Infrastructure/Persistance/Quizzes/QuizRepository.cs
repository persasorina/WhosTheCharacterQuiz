using WhosTheCharacterQuiz.Domain.Persistance;
using WhosTheCharacterQuiz.Domain.Quizzes;

namespace WhosTheCharacterQuiz.Infrastructure.Persistance.Quizzes;
public sealed class QuizRepository : IQuizRepository
{
    private static readonly List<Quiz> _quizzes = new();
    public async Task AddAsync(Quiz quiz)
    {
        await Task.CompletedTask;
        _quizzes.Add(quiz);
    }

    public async Task<Quiz?> GetQuizByNameAsync(string name)
    {
        await Task.CompletedTask;
        return _quizzes.FirstOrDefault(quiz => quiz.Name == name);
    }

    public async Task<Quiz?> GetQuizByIdAsync(string id)
    {
        await Task.CompletedTask;
        return _quizzes.FirstOrDefault(quiz => quiz.Id.Value.ToString() == id);
    }
}
