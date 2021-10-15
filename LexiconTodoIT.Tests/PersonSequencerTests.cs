using LexiconTodoIT.Data;
using System;
using Xunit;

namespace LexiconTodoIT.Tests
{
    public class PersonSequencerTests
    {
        [Fact]
        public void CallingNextPersonIdMethodShouldReturnIncrementedPersonId()
        {
            PersonSequencer.reset(); 
            int idAfterIncrementMethodCall = 1;
            Assert.Equal(idAfterIncrementMethodCall, PersonSequencer.nextPersonId());

            PersonSequencer.reset();
            PersonSequencer.nextPersonId();
            PersonSequencer.nextPersonId();
            int idAfterSecondIncrementMethodCall = 3;
            Assert.Equal(idAfterSecondIncrementMethodCall, PersonSequencer.nextPersonId());

            PersonSequencer.reset();

        }

        [Fact]
        public void CallingResetMethodShouldReturnZeroPersonId()
        {
            PersonSequencer.reset();
            int idAfterIncrementMethodCall = 1;
            int idAfterResetMethodCall = 0;

            Assert.Equal(idAfterIncrementMethodCall, PersonSequencer.nextPersonId());

            PersonSequencer.reset();

            Assert.Equal(idAfterResetMethodCall, PersonSequencer.PersonId);
        }
    }
}
