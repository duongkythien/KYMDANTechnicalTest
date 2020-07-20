using DATA;
using MODEL;
using System.Collections.Generic;

namespace MODULE
{
    public interface ITodoListService
    {
        TodoList GetTodoItemById(long id);
        TodoList Insert(TodoListDTO todoItem);
        List<TodoList> Search(string description, string category_name, int? status, int limit, int offset);

        TodoList Update(long id, TodoListDTO todoItem);
    }
}