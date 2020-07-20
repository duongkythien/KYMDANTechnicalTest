using DATA;
using REPOSITORY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODULE
{
    public class CategoryService : ICategoryService
    {
        private IRepository<Category> _categoryRepo;
        public CategoryService(IRepository<Category> categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public List<Category> GetCategories()
        {
            return _categoryRepo.GetAll().ToList();
        }

        public Category GetCategoryById(long id)
        {
            return _categoryRepo.Get(id);
        }

        public Category FindCategoryBy(string name)
        {
            return _categoryRepo.GetAll().FirstOrDefault(s => s.Name == name);
        }

        public Category Insert(string categoryName)
        {
            Category newItem = new Category
            {
                Name = categoryName
            };
            return _categoryRepo.Insert(newItem);
        }

        public int Delete(long id)
        {
            return _categoryRepo.Delete(id);
        }

        public Category Update(long id, string categoryName)
        {
            Category newItem = new Category
            {
                Id = id,
                Name = categoryName
            };
            return _categoryRepo.Update(newItem);
        }
    }
}
