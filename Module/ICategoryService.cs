using DATA;
using System.Collections.Generic;

namespace MODULE
{
    public interface ICategoryService
    {
        List<Category> GetCategories();
        Category GetCategoryById(long id);
        Category Insert(string categoryName);

        Category FindCategoryBy(string name);

        int Delete(long id);

        Category Update(long id, string category_name);
    }
}