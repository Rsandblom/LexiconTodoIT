using LexiconTodoIT.Model;
using System;
using Xunit;

namespace LexiconTodoIT.Tests
{
    public class TodoTests
    {
        [Fact]
        public void CreateWithIdAndDescription()
        {
            int id = 1;
            string description = "TheDescription";

            Todo todoToTest = new Todo(id, description);

            Assert.NotNull(todoToTest);
            Assert.Equal(id, todoToTest.TodoId);
            Assert.Equal(description, todoToTest.Description);

        }
    }
}
