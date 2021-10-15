using LexiconTodoIT.Data;
using System;
using Xunit;

namespace LexiconTodoIT.Tests
{
    public class TodoSequencerTests
    {
        [Fact]
        public void CallingNextTodoIdMethodShouldReturnIncrementedTodoId()
        {
            TodoSequencer.reset();
            int idAfterIncrementMethodCall = 1;
            int idAfterSecondIncrementMethodCall = 2;

            Assert.Equal(idAfterIncrementMethodCall, TodoSequencer.nextTodoId());
            Assert.Equal(idAfterSecondIncrementMethodCall, TodoSequencer.nextTodoId());

            TodoSequencer.reset();

        }

        [Fact]
        public void CallingResetMethodShouldReturnZeroTodoId()
        {
            TodoSequencer.reset();
            int idAfterIncrementMethodCall = 1;
            int idAfterResetMethodCall = 0;

            Assert.Equal(idAfterIncrementMethodCall, TodoSequencer.nextTodoId());

            TodoSequencer.reset();

            Assert.Equal(idAfterResetMethodCall, TodoSequencer.TodoId);

        }

    }
}
