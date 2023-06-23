namespace ReviewApp.Models
{
    public class Reviews
    {
        public int Id { get; set; } 
        public int rating { get; set; } 

        public string Title { get; set; }

        public string text { get; set; }


        //one to one
        public Reviewers reviewer { get; set; } 

        public Character character { get; set; }

    }
}
