using ReviewApp.Models;

namespace ReviewApp.Interfaces
{
    public interface IReviewerRepository
    {

        ICollection<Reviewers> GetReviewers();

        Reviewers GetReviewer(int reviewerId);

        bool ReviewerExists(int reviewerId);

        ICollection<Reviews> GetReviewsByReviewer(int reviewerId);

        bool CreateReviewer(Reviewers reviewers);
        bool UpdateReviewer(Reviewers reviewers);

        bool save();




    }
}
