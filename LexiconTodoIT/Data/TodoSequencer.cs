using System;
using System.Collections.Generic;
using System.Text;

namespace LexiconTodoIT.Data
{
    public class TodoSequencer
    {
        private static int todoId;

        public static int TodoId { get { return todoId; } }

        public static int nextTodoId()
        {
            todoId++;
            return TodoId;
        }

        public static void reset()
        {
            todoId = 0;
        }
    }
}
