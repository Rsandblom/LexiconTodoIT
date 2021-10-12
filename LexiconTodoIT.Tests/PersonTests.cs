using LexiconTodoIT.Model;
using System;
using Xunit;

namespace LexiconTodoIT.Tests
{
    public class PersonTests
    {
        [Fact]
        public void CreateWithAllParametersInConstructor()
        {
            int id = 1;
            string firstName = "TheFirstName";
            string lastName = "TheLastName";

            Person personToTest = new Person(id, firstName, lastName);

            Assert.NotNull(personToTest);
            Assert.Equal(id, personToTest.PersonId);
            Assert.Equal(firstName, personToTest.FirstName);
            Assert.Equal(lastName, personToTest.LastName);


        }

        [Theory]
        [InlineData("", "TheLastName")]
        [InlineData(null, "TheLastName")]
        public void EmptyOrNullFirstNameParametersInConstructorShouldThrowException(string firstName, string lastName)
        {
            int id = 1;
            string exceptionMessage = $"'firstName' cannot be null or empty.";

            ArgumentException result =  Assert.Throws<ArgumentException>( () =>  new Person(id, firstName, lastName));

            Assert.Equal(exceptionMessage, result.Message);
        }

        [Theory]
        [InlineData("TheFirstName", "")]
        [InlineData("TheFristName", null)]
        public void EmptyOrNullLastNameParametersInConstructorShouldThrowException(string firstName, string lastName)
        {
            int id = 1;
            string exceptionMessage = $"'lastName' cannot be null or empty.";

            ArgumentException result = Assert.Throws<ArgumentException>(() => new Person(id, firstName, lastName));

            Assert.Equal(exceptionMessage, result.Message);
        }
    }
}
