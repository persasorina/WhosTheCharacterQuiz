using ErrorOr;
using StrawberryShake;
using WhosTheCharacterQuiz.Application.Services.Characters;
using WhosTheCharacterQuiz.Domain.Common.Errors;

namespace WhosTheCharacterQuiz.Infrastructure.Persistance.Characters;
public sealed class CharacterRepository : ICharacterRepository
{
    private readonly IRickAndMortyClient _client;
    public CharacterRepository(IRickAndMortyClient client)
    {
        _client = client;
    }
    public async Task<ErrorOr<IEnumerable<Character>>> GetAllCharactersAsync()
    {
        var getAllCharactersResult = await _client.GetAllCharacters.ExecuteAsync();
        getAllCharactersResult.EnsureNoErrors();

        IReadOnlyList<IGetAllCharacters_Characters_Results?>? characterResults = getAllCharactersResult.Data?.Characters?.Results;

        if (characterResults is null)
        {
            return Errors.Quiz.CharacterRetrievalFailed;            
        }
        var characters = new HashSet<Character>();
        foreach (IGetAllCharacters_Characters_Results_Character? characterResult in characterResults)
        {
            if (characterResult is null ||
                !characterResult.IsValid())
            {
                continue;
            }
#pragma warning disable CS8604
            var character = new Character(characterResult.Id, characterResult.Name, characterResult.Image);
#pragma warning restore CS8604

            characters.Add(character);
        }
        return characters.ToList();
    }
}
