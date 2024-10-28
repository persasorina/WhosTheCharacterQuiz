using ErrorOr;

namespace WhosTheCharacterQuiz.Application.Services.Characters;
public interface ICharacterRepository
{    Task<ErrorOr<IEnumerable<Character>>> GetAllCharactersAsync();
}
