namespace WhosTheCharacterQuiz.Contracts.Quizzes;

public record QuizResponse(
    string Id,
    string Name, 
    string Description,
    List<QuestionResponse> Questions);

public record QuestionResponse(
    string Id,
    string Text,
    string ImageUrl,
    AnswerOptionResponse CorrectAnswer,
    List<AnswerOptionResponse> AnswerOptions);

public record AnswerOptionResponse(
    string Answer);