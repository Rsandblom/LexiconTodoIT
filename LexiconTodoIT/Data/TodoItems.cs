using LexiconTodoIT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LexiconTodoIT.Data
{
    public class TodoItems
    {
        private static Todo[] todoArray = new Todo[0];

        public static int Size()
        {
            return todoArray.Length;
        }

        public static Todo[] FindAll()
        {
            return todoArray;
        }

        public static Todo FindById(int todoId)
        {
            Todo todo = todoArray.Where(t => t.TodoId == todoId).FirstOrDefault();
            return todo;
        }

        public static Todo CreateAndAddNewTodoToArrayThenReturnTodo(string description)
        {
            int id = TodoSequencer.nextTodoId();
            Todo newTodo = new Todo(id, description);
            Array.Resize(ref todoArray, todoArray.Length + 1);
            todoArray[todoArray.Length - 1] = newTodo;

            return newTodo;
        }
        public static void Clear()
        {
            Array.Clear(todoArray, 0, todoArray.Length);
        }
    }
}
