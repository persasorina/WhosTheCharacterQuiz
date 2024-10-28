using WhosTheCharacterQuiz.Domain.Quizzes;

namespace WhosTheCharacterQuiz.Domain.Persistance;

public interface IQuizRepository
{
    Task<Quiz?> GetQuizByNameAsync(string name);

    Task AddAsync(Quiz quiz);
}
