using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp
{
    internal class TodoRepository
    {
        private readonly List<Todo> _todos = new();
        private int _nextId = 1;
        private readonly string _filepath = "todos.txt";
        private void LoadFormFile()
        {
            if (!File.Exists(_filepath)) return;
            foreach (var line in File.ReadAllLines(_filepath))
            {
                var item = Todo.FromFileString(line);
                _todos.Add(item);
                if (item.Id >= _nextId)
                    _nextId = item.Id + 1;
            }
        }
        public TodoRepository()
        {
            LoadFormFile();
        }
        public List<Todo> GetAll() => _todos;
        public Todo AddTodo(string title)
        {
            var item = new Todo()
            {
                Id = _nextId++,
                Title = title,
                IsSuccess = false
            };
            _todos.Add(item);
            SaveChanges();
            return item;
        }

        private void SaveChanges()
        {
            File.WriteAllLines(
                _filepath, 
                _todos.Select(x => x.ToFileString())
            );
        }
        public bool UpdateTodo(int id, string newtitle)
        {
            var item = _todos.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                item.Title = newtitle;
                SaveChanges();
                return true;
            }
            return false;
        }
        public bool DeleteTodo(int id)
        {
            var item = _todos.FirstOrDefault(x => x.Id == id);
            if(item != null)
            {
                _todos.Remove(item);
                SaveChanges();
                return true;
            }
            return false;
        }
        public bool ToggleTodo(int id)
        {
            var item = _todos.FirstOrDefault(x=> x.Id == id);
            if( item != null)
            {
                item.IsSuccess = !item.IsSuccess;
                SaveChanges() ;
                return true;
            }
            return false;
        }
    }
}
