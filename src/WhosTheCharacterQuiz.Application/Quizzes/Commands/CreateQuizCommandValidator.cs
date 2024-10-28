using FluentValidation;

namespace WhosTheCharacterQuiz.Application.Quizzes.Commands;
public class CreateQuizCommandValidator:AbstractValidator<CreateQuizCommand>
{
    public CreateQuizCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.NumberOfQuestions).LessThanOrEqualTo(10).GreaterThan(0);
    }
}
