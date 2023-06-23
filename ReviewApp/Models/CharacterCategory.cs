namespace ReviewApp.Models
{
    public class CharacterCategory
    {
        public int CharacterId { get; set; }
        public int CategoryId { get; set; }

        public Character Character { get; set; }    
        public Category Category { get; set; }
    }
}
