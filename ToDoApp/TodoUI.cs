using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp
{
    public class TodoUI
    {
        private readonly TodoService _service = new();
        private void ShowTodos()
        {
            var todos = _service.GetAllTodo();
            Console.WriteLine("=====DANH SÁCH NHIỆM VỤ=====");
            foreach (var todo in todos)
            {
                Console.WriteLine(todo);
            }
            if (todos.Count == 0)
            {
                Console.WriteLine("Chưa có nhiệm vụ!");
            }
        }
        private void ShowMenu()
        {
            Console.WriteLine("Chức năng: ");
            Console.WriteLine("1. Thêm Todo");
            Console.WriteLine("2. Xoá Todo");
            Console.WriteLine("3. Đánh dấu hoàn thành");
            Console.WriteLine("4. Sửa nội dung");
            Console.WriteLine("0. Thoát");
            Console.Write("Chọn: ");
        }
        private void AddTodo()
        {
            Console.Write("Nhập nội dung nhiệm vụ: ");
            string todo = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(todo))
                _service.AddTodo(todo);
        }
        private void DeleteTodo()
        {
            Console.Write("Nhập ID cần xoá: ");
            int id = int.Parse(Console.ReadLine());
            _service.DeleteTodo(id);
        }
        private void ToggleTodo()
        {
            Console.Write("Nhập ID muốn đánh dấu: ");
            int id = int.Parse(Console.ReadLine());
            _service.ToggleTodo(id);
        }
        private void UpdateTodo()
        {
            Console.Write("Nhập ID muốn thay đổi: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Nhập nội dung mới: ");
            string title = Console.ReadLine();
            _service.UpdateTodo(id, title);
        }
        public void Run()
        {
            while (true)
            {
                Console.Clear();
                ShowTodos();
                ShowMenu();

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddTodo();
                        break;
                    case "2":
                        DeleteTodo();
                        break;
                    case "3":
                        ToggleTodo();
                        break;
                    case "4":
                        UpdateTodo();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ!");
                        break;
                }
                Console.WriteLine("Nhấn Enter để tiếp tục...");
                Console.ReadLine();
            }
        }
    }
}