using ReviewApp.Models;

namespace ReviewApp.Interfaces
{
    public interface IOwnerRespository
    {
        ICollection<Owner> GetOwners();

        Owner GetOwner(int id);

        ICollection<Owner> GetOwnerOfCharacter(int Characterid);

        ICollection<Character> GetCharacterByOwner(int ownerId);

        bool OwnerExists(int ownerId);
    }
}
