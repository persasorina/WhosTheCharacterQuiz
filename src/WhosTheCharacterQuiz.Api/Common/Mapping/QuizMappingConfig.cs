using Mapster;
using WhosTheCharacterQuiz.Application.Quizzes.Commands;
using WhosTheCharacterQuiz.Api.Contracts.Quizzes;
using WhosTheCharacterQuiz.Domain.QuizModels.Entities;
using WhosTheCharacterQuiz.Domain.QuizModels.ValueObjects;
using WhosTheCharacterQuiz.Domain.Quizzes;

namespace WhosTheCharacterQuiz.Api.Common.Mapping;

public class QuizMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateQuizRequest, CreateQuizCommand>();        

        config.NewConfig<Quiz, QuizResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);

        config.NewConfig<Question, QuestionResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);
        config.NewConfig<AnswerOption, AnswerOptionResponse>()
            .Map(dest => dest.Answer, src => src.Answer); 
    }
}
