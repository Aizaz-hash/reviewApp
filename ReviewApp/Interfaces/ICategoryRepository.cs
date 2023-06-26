using ReviewApp.Models;

namespace ReviewApp.Interfaces
{
    public interface ICategoryRepository 
    {

        ICollection<Category> GetCategories();
        Category GetCategory(int id);
        ICollection<Character> GetCharacterByCategoryId(int categoryId);
        bool CategoriesExists(int id);

        bool CreateCategory(Category category);

        bool save();
    }
}
