using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public bool CreateReview(Reviews review)
        {
            _context.Add(review);

            return save();
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
        public bool save()
        {

            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }

        public bool UpdateReview(Reviews review)
        {
            _context.Update(review);

            return save();
        }
    }
}
