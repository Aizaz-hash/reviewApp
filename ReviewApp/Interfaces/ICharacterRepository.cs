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

        bool CreateCharacter(int ownerId , int categoryId , Character character);

        bool UpdateCharacter(int ownerId, int categoryId, Character character);

        bool save();
    }
}
