namespace ReviewApp.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string Gym { get; set; }


        //one to one
        public Country country { get; set; }

        //many to many
        public ICollection<CharacterOwner> CharacterOwners { get; set; }

    }
}
