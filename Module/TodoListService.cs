using DATA;
using Microsoft.EntityFrameworkCore;
using MODEL;
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
        public TodoListService(IRepository<TodoList> todoRepo)
        {
            _todoRepo = todoRepo;
        }

        public TodoList GetTodoItemById(long id)
        {
            return _todoRepo.Get(id);
        }

        public TodoList Insert(TodoListDTO todoItem)
        {
            TodoList todoListItem = new TodoList
            {
                Name = todoItem.Name,
                CategoryId = todoItem.CategoryId,
                Description = todoItem.Description,
                DueDate = todoItem.DueDate,
                Status = (byte)todoItem.Status
            };
            return _todoRepo.Insert(todoListItem);
        }

        public TodoList Update(long id, TodoListDTO todoItem)
        {
            TodoList todoListItem = new TodoList
            {
                Id = id,
                Name = todoItem.Name,
                CategoryId = todoItem.CategoryId,
                Description = todoItem.Description,
                DueDate = todoItem.DueDate,
                Status = (byte)todoItem.Status
            };
            return _todoRepo.Update(todoListItem);
        }

        public List<TodoList> Search(string description, string category_name, int? status, int limit, int offset)
        {
            IQueryable<TodoList> todoList = _todoRepo.GetAll().Include(s=>s.Category);
            if(!string.IsNullOrEmpty(description) && !string.IsNullOrWhiteSpace(description)) 
                todoList = todoList.Where(s => s.Description.Contains(description));

            if(!string.IsNullOrEmpty(category_name) && !string.IsNullOrWhiteSpace(category_name))
                todoList = todoList.Where(s => s.Category.Name == category_name);

            if(status.HasValue) 
                todoList = todoList.Where(s => s.Status == status.Value);

            return todoList.Take(limit).Skip(limit * (offset - 1)).OrderByDescending(s=>s.Id).ToList();
        }
    }
}
