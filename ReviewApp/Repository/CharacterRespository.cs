using Microsoft.EntityFrameworkCore;
using ReviewApp.Data;
using ReviewApp.Interfaces;
using ReviewApp.Models;

namespace ReviewApp.Repository
{
    public class CharacterRespository : ICharacterRespsoitory
    {
        private  DataContext _Context;
        public CharacterRespository(DataContext context)
        {
         
            _Context = context;
        }

       public ICollection<Character> GetCharacters() {

            return _Context.characters.OrderBy(p=>p.Id).ToList();
        
        }

        public Character GetCharacter(int id)
        {
            return _Context.characters.Where(p => p.Id == id).FirstOrDefault();
        }

        public Character GetCharacter(string name)
        {
            return _Context.characters.Where(p => p.Name == name).FirstOrDefault();
        }

        public decimal GetCharacterRating(int characterID)
        {

            var review = _Context.reviews.Where(p => p.character.Id == characterID);

            if (review.Count() <= 0)
                return 0;

            return ((decimal)review.Sum(r => r.rating) / review.Count());
        }

        public bool CharacterExists(int characterID)
        {
            return _Context.characters.Any(p=>p.Id== characterID);
        }

    }
}
