using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YB.ToDoAPI.DTOs;
using YB.ToDoAPI.Interfaces;
using YB.ToDoAPI.Models;

namespace YB.ToDoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoRepository _toDoRepository;

        public ToDoController(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllToDoItems()
        {
            var toDoItems = await _toDoRepository.GetToDoItems();
            if(toDoItems == null)
            {
                return NotFound();
            }
            return Ok(toDoItems);
        }

        [HttpPost]
        public async Task<ActionResult<ToDoItemDTO>> CreateTodoItem([FromBody] ToDoItemDTO todoItemDTO)
        {
            var todoItem = new ToDoItem
            {
                IsComplete = todoItemDTO.IsComplete,
                Description = todoItemDTO.Description
            };

            var result = await _toDoRepository.CreateToDoItem(todoItem);

            return CreatedAtAction(nameof(CreateTodoItem), new {toDoItem = result}, todoItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateToDoItem(int id, ToDoItem item)
        {
            if(item == null || item.Id == null || id != item.Id)
            {
                return BadRequest();
            }

            try
            {
                await _toDoRepository.UpdateToDoItem(item);
            }
            catch (DbUpdateConcurrencyException) when (!_toDoRepository.TodoItemExists(id))
            {
                return NotFound();
            }
            return Ok(new { message = "ToDo updated"});
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDoItem(int id)
        {
            if(_toDoRepository.TodoItemExists(id))
            {
                var result = await _toDoRepository.DeleteToDoItem(id);
                return Ok(result);
            }
            return NotFound();
        }

    }
}
