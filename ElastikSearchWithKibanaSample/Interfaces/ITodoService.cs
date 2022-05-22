using ElastikSearchWithKibanaSample.Entities;
using ElastikSearchWithKibanaSample.Wrapper;

namespace ElastikSearchWithKibanaSample.Interfaces
{
    public interface ITodoService
    {
        Task<Response<string>> CreateNewTodo(Todo todo);
        Task<Response<string>> UpdateTodo(Todo todo);
        Task<Response<string>> DeleteTodo(int Id);
        Task<Response<IEnumerable<Todo>>> GetAllTodos();
        Task<Response<Todo>> GetTodoById(int Id);
    }
}
