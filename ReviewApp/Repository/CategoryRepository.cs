using ReviewApp.Data;
using ReviewApp.Interfaces;
using ReviewApp.Models;

namespace ReviewApp.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public bool CategoriesExists(int id)
        {
            return _context.Categories.Any(c => c.Id == id);
        }

        public bool CreateCategory(Category category)
        {
            _context.Add(category);

            return save();
        }

        public bool DeleteCategory(Category category)
        {
            _context.Remove(category);
            return save();
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.Where(e => e.Id == id).FirstOrDefault();
        }

        public ICollection<Character> GetCharacterByCategoryId(int categoryId)
        {
            return _context.characterCategories.Where(e => e.CategoryId == categoryId).Select(c => c.Character).ToList();
        }

        public bool save()
        {
            var save = _context.SaveChanges();

            return save > 0? true: false;
        }

        public bool UpdateCategory(Category category)
        {
            _context.Update(category);

            return save();
        }
    }
}
