using ErrorOr;

namespace WhosTheCharacterQuiz.Domain.Common.Errors;
public static class Errors
{
    public static class Quiz
    {
        public static Error DuplicateQuizName => Error.Conflict(
            code: "Quiz.DuplicateName",
            description: "A quiz with an identical name exists."
            );
        public static Error InsufficientCharacters => Error.Failure(
           code: "Quiz.NotEnoughCharcters",
           description: "The number of characters is not enough."
           );

        public static Error CharacterRetrievalFailed => Error.Failure(
            code: "Quiz.CharacterRetrievalFailure",
            description: "The retrieval of characters failed."
           );
    }
}
