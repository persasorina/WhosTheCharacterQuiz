namespace WhosTheCharacterQuiz.Contracts.Quizzes;

public record CreateQuizRequest(    
    string Name,
    string Description,
    int NumberOfQuestions);



