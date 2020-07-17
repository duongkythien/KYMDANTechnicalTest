using DATA;
using REPOSITORY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODULE
{
    public class TodoListService : ITodoListService
    {
        private IRepository<TodoList> _todoRepo;
        private ICategoryService _categoryService;
        public TodoListService(IRepository<TodoList> todoRepo, ICategoryService categoryService)
        {
            _todoRepo = todoRepo;
            _categoryService = categoryService;
        }

        public List<TodoList> GetCategories()
        {
            return _todoRepo.GetAll().ToList();
        }

        public TodoList GetTodoItemById(long id)
        {
            return _todoRepo.Get(id);
        }

        public TodoList Insert(TodoList todoItem)
        {
            return _todoRepo.Insert(todoItem);
        }

        public List<TodoList> Search(string description, string category_name, int? status, int? limit = 10, int? offset = 1)
        {
            IQueryable<TodoList> todoList = _todoRepo.GetAll();
            if(!string.IsNullOrEmpty(description) && !string.IsNullOrWhiteSpace(description)) todoList = todoList.Where(s => s.Description.Contains(description));

            if(!string.IsNullOrEmpty(category_name) && !string.IsNullOrWhiteSpace(category_name))
            {
                Category category = _categoryService.FindCategoryBy(category_name);
                if(category != null)
                    todoList = todoList.Where(s => s.CategoryId == category.Id);
            }

            if(status.HasValue) todoList = todoList.Where(s => s.Status == status.Value);
            return todoList.Take(limit.Value).Skip(limit.Value * offset.Value).OrderByDescending(s=>s.Id).ToList();
        }
    }
}
