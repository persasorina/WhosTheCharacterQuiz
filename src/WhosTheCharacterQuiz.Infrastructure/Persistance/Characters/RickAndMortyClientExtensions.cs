namespace WhosTheCharacterQuiz.Infrastructure;
public partial interface IGetAllCharacters_Characters_Results_Character
{
    bool IsValid();
}
public partial class GetAllCharacters_Characters_Results_Character
{
    public bool IsValid()
    {
        return !string.IsNullOrEmpty(Id) &&
           !string.IsNullOrEmpty(Name) &&
           !string.IsNullOrEmpty(Image);
    }
}
