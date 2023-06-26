using AutoMapper;
using ReviewApp.Data;
using ReviewApp.Interfaces;
using ReviewApp.Models;

namespace ReviewApp.Repository
{
    public class ReviewRespository : IReviewRespository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ReviewRespository(DataContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Reviews GetReview(int reviewID)
        {
            return _context.reviews.Where(r=>r.Id == reviewID).FirstOrDefault();
        }

        public ICollection<Reviews> GetReviews()
        {

            return _context.reviews.ToList();
        }

        public ICollection<Reviews> GetReviewsOfCharacter(int characterID)
        {
            return _context.reviews.Where(r=> r.character.Id == characterID).ToList();
        }

        public bool ReviewExists(int reviewID)
        {

            return _context.reviews.Any(r=>r.Id== reviewID);
        }
    }
}
