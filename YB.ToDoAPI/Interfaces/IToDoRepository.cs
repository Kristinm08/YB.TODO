using YB.ToDoAPI.Models;

namespace YB.ToDoAPI.Interfaces
{
    public interface IToDoRepository
    {
        Task<List<ToDoItem>> GetToDoItems();
        Task<int> CreateToDoItem(ToDoItem todoItem);
        Task<bool> UpdateToDoItem(ToDoItem todoItem);
        Task<bool> DeleteToDoItem(int id);
        bool TodoItemExists(int id);
    }
}
