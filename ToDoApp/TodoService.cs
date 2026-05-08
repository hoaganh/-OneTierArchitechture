using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp
{
    internal class TodoService
    {
        private readonly TodoRepository _repository = new();
        public List<Todo> GetAllTodo() => _repository.GetAll();
        public Todo AddTodo(string title) => _repository.AddTodo(title);
        public bool UpdateTodo(int id, string title) =>
            _repository.UpdateTodo(id, title);
        public bool DeleteTodo(int id) => _repository.DeleteTodo(id);
        public bool ToggleTodo(int id) => _repository.ToggleTodo(id);
    }
}
