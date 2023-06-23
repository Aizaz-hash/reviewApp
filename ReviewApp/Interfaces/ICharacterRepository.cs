using ReviewApp.Models;

namespace ReviewApp.Interfaces
{
    public interface ICharacterRespsoitory 
    {
        ICollection<Character> GetCharacters();
        Character GetCharacter(int id);
        Character GetCharacter(string name);

        decimal GetCharacterRating(int characterID);

        bool CharacterExists(int characterID);
    }
}
