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
            int idAfterSecondIncrementMethodCall = 2;

            Assert.Equal(idAfterIncrementMethodCall, PersonSequencer.nextPersonId() );
            Assert.Equal(idAfterSecondIncrementMethodCall, PersonSequencer.nextPersonId());

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
