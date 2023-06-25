using ReviewApp.Data;
using ReviewApp.Interfaces;
using ReviewApp.Models;

namespace ReviewApp.Repository
{
    public class OwnerRespository : IOwnerRespository
    {

        private DataContext _context;

        public OwnerRespository(DataContext context)
        {
            _context = context;
            
        }
        public ICollection<Character> GetCharacterByOwner(int ownerId)
        {
            return _context.characterOwners.Where(p => p.OwnerId == ownerId).Select(c => c.character).ToList();
        }

        public Owner GetOwner(int id)
        {

            return _context.owners.Where(o => o.Id == id).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnerOfCharacter(int Characterid)
        {
            return _context.characterOwners.Where(co => co.CharacterId == Characterid).Select(o => o.owner).ToList();
        }

        public ICollection<Owner> GetOwners()
        {
            return _context.owners.ToList();
        }

        public bool OwnerExists(int ownerId)
        {
            return _context.owners.Any(o => o.Id == ownerId);
        }
    }
}

