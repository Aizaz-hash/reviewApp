namespace ReviewApp.Models
{
    public class Reviewers
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }


        //one to many
        public ICollection<Reviews> reviews { get; set; }

    }
}
