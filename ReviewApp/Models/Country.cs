namespace ReviewApp.Models
{
    public class Country
    {
           public int Id { get; set; }
        public string Name { get; set; }

        //one to many
        public ICollection<Owner> owners { get; set; }
    }
}
