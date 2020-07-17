using DATA;
using System.Collections.Generic;

namespace MODULE
{
    public interface ITodoListService
    {
        List<TodoList> GetCategories();
        TodoList GetTodoItemById(long id);
        TodoList Insert(TodoList todoItem);
        List<TodoList> Search(string description, string category_name, int? status, int? limit, int? offset);
    }
}