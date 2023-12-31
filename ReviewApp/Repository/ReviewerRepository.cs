﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReviewApp.Data;
using ReviewApp.Interfaces;
using ReviewApp.Models;

namespace ReviewApp.Repository
{
    public class ReviewerRepository : IReviewerRepository
    {

        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ReviewerRepository(DataContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            
        }

        public bool CreateReviewer(Reviewers reviewers)
        {
            _context.Add(reviewers);

            return save();
        }

        public bool DeleteReviewer(Reviewers reviewers)
        {
            _context.Remove(reviewers); 
            return save();
        }

        public Reviewers GetReviewer(int reviewerId)
        {
            return _context.reviewers.Where(r=>r.Id == reviewerId).Include(e=>e.reviews) .FirstOrDefault();
        }

        public ICollection<Reviewers> GetReviewers()
        {
            return _context.reviewers.ToList();
        }

        public ICollection<Reviews> GetReviewsByReviewer(int reviewerId)
        {
            return _context.reviews.Where(r => r.reviewer.Id == reviewerId).ToList();

        }

        public bool ReviewerExists(int reviewerId)
        {

            return _context.reviewers.Any(r => r.Id == reviewerId);
        }

        public bool save()
        {

            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }

        public bool UpdateReviewer(Reviewers reviewers)
        {
            _context.Update(reviewers);

            return save();
        }
    }
}
