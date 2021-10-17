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
            Array.Resize(ref todoArray, 0);
        }

        public static Todo[] FindByDoneStatus(bool doneStatus)
        {

            int numberOfTodosWithCorrectDoneStatus = todoArray.Count(t => t.Done == doneStatus);
            Todo[] tempDoneStatusArray = new Todo[numberOfTodosWithCorrectDoneStatus];
            int index = 0;

            foreach  (Todo todo in todoArray)
            {
                if (todo.Done == doneStatus)
                    tempDoneStatusArray[index++] = todo;
            }
            
            return tempDoneStatusArray;

        }

        public static Todo[] FindByAssignees(int personId)
        {

            int numberOfAssigneesWithPersonId = todoArray.Count(t => t.Assignee.PersonId == personId);
            Todo[] tempAssigneePersonIdArray = new Todo[numberOfAssigneesWithPersonId];
            int index = 0;

            foreach (Todo todo in todoArray)
            {
                if (todo.Assignee.PersonId == personId)
                    tempAssigneePersonIdArray[index++] = todo;
            }

            return tempAssigneePersonIdArray;

        }

        public static Todo[] FindByAssignees(Person assignee)
        {

            int numberOfAssignees = todoArray.Count(t => t.Assignee == assignee);
            Todo[] tempAssigneeArray = new Todo[numberOfAssignees];
            int index = 0;

            foreach (Todo todo in todoArray)
            {
                if (todo.Assignee == assignee)
                    tempAssigneeArray[index++] = todo;
            }

            return tempAssigneeArray;

        }

        public static Todo[] FindByUnassignedTodoItems()
        {

            int numberOfUnAssignedItems = todoArray.Count(t => t.Assignee == null);
            Todo[] tempUnAssignedArray = new Todo[numberOfUnAssignedItems];
            int index = 0;

            foreach (Todo todo in todoArray)
            {
                if (todo.Assignee == null)
                    tempUnAssignedArray[index++] = todo;
            }

            return tempUnAssignedArray;

        }

        public static void RemoveTodoItem(int todoId)
        {
            todoArray = todoArray.Where(t => t.TodoId != todoId).ToArray();
        }
    }
}
