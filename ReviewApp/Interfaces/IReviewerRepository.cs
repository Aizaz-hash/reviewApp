using ReviewApp.Models;

namespace ReviewApp.Interfaces
{
    public interface IReviewerRepository
    {

        ICollection<Reviewers> GetReviewers();

        Reviewers GetReviewer(int reviewerId);

        bool ReviewerExists(int reviewerId);

        ICollection<Reviews> GetReviewsByReviewer(int reviewerId);


    }
}
