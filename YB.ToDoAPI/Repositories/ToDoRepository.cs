using Microsoft.EntityFrameworkCore;
using YB.ToDoAPI.Data;
using YB.ToDoAPI.Interfaces;
using YB.ToDoAPI.Models;

namespace YB.ToDoAPI.Repositories
{
    public class ToDoRepository: IToDoRepository
    {
        private readonly DataContext _context;

        public ToDoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<ToDoItem>> GetToDoItems()
        {
            return await _context.ToDoItem.ToListAsync();
        }

        public bool TodoItemExists(int id)
        {
            return _context.ToDoItem.Any(e => e.Id == id);
        }

        public async Task<int> CreateToDoItem(ToDoItem todoItem)
        {
            _context.ToDoItem.Add(todoItem);
            var id = await _context.SaveChangesAsync();
            return id;
        }

        public async Task<bool> UpdateToDoItem(ToDoItem item)
        {
            var selectedItem = await _context.ToDoItem.FindAsync(item.Id);
            if (selectedItem == null)
                throw new DbUpdateConcurrencyException();
            selectedItem.Description = item.Description;
            selectedItem.ModifiedDate = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteToDoItem(int id)
        {
            var toDoItem = await _context.ToDoItem.FindAsync(id);
            if (toDoItem == null) return false;
            _context.ToDoItem.Remove(toDoItem);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
