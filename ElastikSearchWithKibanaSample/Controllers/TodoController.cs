using ElastikSearchWithKibanaSample.Entities;
using ElastikSearchWithKibanaSample.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ElastikSearchWithKibanaSample.Controllers
{
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet("/Get")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _todoService.GetAllTodos());
        }

        [HttpGet("/GetById/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            return Ok(await _todoService.GetTodoById(Id));
        }

        [HttpPost("/Create")]
        public async Task<IActionResult> Create(Todo todoModel)
        {
            return Ok(await _todoService.CreateNewTodo(todoModel));
        }


        [HttpPost("/Update")]
        public async Task<IActionResult> Update(Todo todoModel)
        {
            return Ok(await _todoService.UpdateTodo(todoModel));
        }


        [HttpGet("/Delete/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            return Ok(await _todoService.DeleteTodo(Id));
        }
    }
}
