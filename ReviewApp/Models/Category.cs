namespace ReviewApp.Models
{
    public class Category
    {

        public int Id { get; set; }
        public string Name { get; set; }

        //many to many
        public ICollection<CharacterCategory> Categories { get; set; }
    }
}
