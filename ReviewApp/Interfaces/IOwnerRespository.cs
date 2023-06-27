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

        public bool CreateOwner(Owner owner);
        public bool save();

        bool UpdateOwner(Owner owner);

        public bool DeleteOwner(Owner owner);


    }
}
