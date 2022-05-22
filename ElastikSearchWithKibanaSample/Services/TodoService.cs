using ElastikSearchWithKibanaSample.Entities;
using ElastikSearchWithKibanaSample.Interfaces;
using ElastikSearchWithKibanaSample.Wrapper;

namespace ElastikSearchWithKibanaSample.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<Response<string>> CreateNewTodo(Todo todo)
        {
            await _todoRepository.Add(todo);
            return new Response<string>("Added Successfuly", true);
        }

        public async Task<Response<string>> UpdateTodo(Todo todo)
        {
            var todoItem = await _todoRepository.GetByIdAsync(todo.ID);

            if (todoItem is null) throw new ArgumentNullException("Todo item doesn`t find!");

            todoItem.Title = todo.Title;
            todoItem.Description = todo.Description;

            await _todoRepository.Update(todoItem);

            return new Response<string>("Added Successfuly", true);
        }
        public async Task<Response<string>> DeleteTodo(int Id)
        {
            var todoItem = await _todoRepository.GetByIdAsync(Id);

            if (todoItem is null) throw new ArgumentNullException("Todo item doesn`t find!");
            await _todoRepository.Remove(todoItem);

            return new Response<string>("Added Successfuly", true);
        }

        public async Task<Response<IEnumerable<Todo>>> GetAllTodos()
        {
            var result = await _todoRepository.GetAllAsync();
            return new Response<IEnumerable<Todo>>(result, "");
        }

        public async Task<Response<Todo>> GetTodoById(int Id)
        {
            var result = await _todoRepository.GetByIdAsync(Id);
            return new Response<Todo>(result, "");
        }

    }
}
