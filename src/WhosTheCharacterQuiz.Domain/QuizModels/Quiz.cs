using WhosTheCharacterQuiz.Domain.Common.Models;
using WhosTheCharacterQuiz.Domain.QuizModels.Entities;
using WhosTheCharacterQuiz.Domain.QuizModels.ValueObjects;

namespace WhosTheCharacterQuiz.Domain.Quizzes;

public sealed class Quiz:AggregateRoot<QuizId>
{
    private readonly List<Question> _questions = new();
    private Quiz(QuizId id, 
        string name, 
        string description,
        List<Question> questions) : base(id)
    {
        Name = name;
        Description = description;        
        _questions = questions;
    }

    public IReadOnlyList<Question> Questions => _questions.AsReadOnly();
    
    public string Name { get; private set; } = null!;
    public string Description { get; private set; } = null!;

    public static Quiz Create(string name, 
        string description,        
        List<Question> questions)
    {
        return new(QuizId.CreateUnique(),
            name,
            description,
            questions
          );
    }
}
