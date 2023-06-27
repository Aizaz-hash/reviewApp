using ReviewApp.Models;

namespace ReviewApp.Interfaces
{
    public interface IReviewRespository
    {
        ICollection<Reviews> GetReviews();

        Reviews GetReview(int reviewID);

        ICollection<Reviews> GetReviewsOfCharacter(int characterID);

        bool ReviewExists(int reviewID);

        bool CreateReview(Reviews review);
        bool UpdateReview(Reviews review);

        bool DeleteReview(Reviews review);
        bool DeleteReviews(List<Reviews> reviews);

        bool save();
    }
}
