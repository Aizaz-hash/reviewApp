namespace ReviewApp.Models
{
    public class CharacterOwner
    {
        public int CharacterId { get; set; }
        public int OwnerId { get; set; }

        public Character character { get; set; }
        public Owner owner { get; set; }



    }
}
