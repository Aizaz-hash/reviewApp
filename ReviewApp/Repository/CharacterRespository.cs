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

        public bool CreateCharacter(int ownerId, int categoryId, Character chracter)
        {
            var characterEntity = _Context.owners.Where(a=>a.Id==ownerId).FirstOrDefault();
            var category = _Context.Categories.Where(c=>c.Id ==categoryId).FirstOrDefault();


            //character owner relationship constructor
            var characterOwner = new CharacterOwner()
            {
                owner = characterEntity,
                character = chracter,
            };

            _Context.Add(characterOwner);

            //character category relationship constructor

            var characterCatgory = new CharacterCategory()
            {
                Category = category,
                Character = chracter,

            };


            _Context.Add(characterCatgory);

            _Context.Add(chracter);

            return save();
        }

        //is saved fucntion
        public bool save()
        {

            var saved = _Context.SaveChanges();

            return saved>0 ?  true:false;
        }

        public bool UpdateCharacter(int ownerId, int categoryId, Character character)
        {
            _Context.Update(character);

            return save();
        }
    }
}
