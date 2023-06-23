namespace ReviewApp.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime DOB { get; set; }

        //one to many
        public ICollection<Reviews> reviews { get; set; }


        //many to many
        public ICollection<CharacterOwner> characterOwners { get; set; }
        public ICollection<CharacterCategory> characterCategories { get; set; }



    }
}
