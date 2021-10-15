using LexiconTodoIT.Data;
using LexiconTodoIT.Model;
using System;
using System.Collections.Generic;
using Xunit;

namespace LexiconTodoIT.Tests
{
    public class TodoItemsTests
    {
        [Fact]
        public void CallingSizeShouldReturnLengthOfArray()
        {
            int lenghtOfArray = 0;
            Assert.Equal(lenghtOfArray, TodoItems.Size());
        }

        [Fact]
        public void CallingFindAllShouldReturnATodoArray()
        {
            Assert.IsType<Todo[]>(TodoItems.FindAll());
        }

        [Fact]
        public void IfTodoArrayDoesNotContainTodoWithIdReturnShouldBeNull()
        {
            Todo todoThatShouldBeNull = TodoItems.FindById(1000000);
            Assert.Null(todoThatShouldBeNull);
        }

        

        [Fact]
        public void CreatedTodoShouldBeAddedToArrayAndReturned()
        {

            int todoId = 2;
            string description = "TheDescription";
            Todo todoOne = TodoItems.CreateAndAddNewTodoToArrayThenReturnTodo(description);

            Assert.Equal(todoId, todoOne.TodoId);
            Assert.Equal(description, todoOne.Description);
        }

        [Fact]
        public void IfTodoArrayContainsTodoWithIdReturnedTodoShouldNotBeNull()
        {
            
            string description = "TheDescription";
            Todo todoOne = TodoItems.CreateAndAddNewTodoToArrayThenReturnTodo(description);
            
            Todo todoThatShouldNotBeNull = TodoItems.FindById(1);
            Assert.NotNull(todoThatShouldNotBeNull);
        }

        [Fact]
        public void CallingClearMethodShouldResultInAnEmptyArray()
        {
            TodoItems.Clear();
            Assert.Null(TodoItems.FindAll()[0]);
        }
    }
}
