using DATA;
using System.Collections.Generic;

namespace MODULE
{
    public interface ICategoryService
    {
        List<Category> GetCategories();
        Category GetCategoryById(long id);
        Category Insert(Category category);

        Category FindCategoryBy(string name);
    }
}