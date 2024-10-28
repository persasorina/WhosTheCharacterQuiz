using Microsoft.AspNetCore.Mvc;
using ErrorOr;
using MediatR;
using WhosTheCharacterQuiz.Api.Contracts.Quizzes;
using WhosTheCharacterQuiz.Application.Quizzes.Commands;
using WhosTheCharacterQuiz.Application.Quizzes.Queries;
using MapsterMapper;
using WhosTheCharacterQuiz.Domain.Quizzes;

namespace WhosTheCharacterQuiz.Api.Controllers
{
    
    [Route("quiz")]
    public class QuizController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;
        public QuizController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateQuizRequest request)
        {
            var command =_mapper.Map<CreateQuizCommand>(request);            
            ErrorOr<Quiz> createQuizResult = await _mediator.Send(command);
            return createQuizResult.Match(
                createQuizResult => Ok(MapQuiz(createQuizResult)),
                errors => Problem(errors));
        }

        [HttpGet]
        public async Task<IActionResult> GetQuizByName(string name)
        {
            var query = new GetQuizQuery(name);
            ErrorOr<Quiz> getQuizResult = await _mediator.Send(query);
            return getQuizResult.Match(
                getQuizResult => Ok(MapQuiz(getQuizResult)),
                errors => Problem(errors));
        }
        private QuizResponse? MapQuiz(Quiz createQuizResult)
        {
            return _mapper.Map<QuizResponse?>(createQuizResult);
        }        
    }
}
