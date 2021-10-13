using LexiconTodoIT.Data;
using LexiconTodoIT.Model;
using System;
using System.Collections.Generic;
using Xunit;

namespace LexiconTodoIT.Tests
{
    public class PeopleTests
    {      
        [Fact]
        public void CallingSizeShouldReturnLengthOfArray()
        {
            int lenghtOfArray = 1;
            Assert.Equal(lenghtOfArray, People.Size());
        }

        [Fact]
        public void CallingFindAllShouldReturnAPersonArray()
        {
            Assert.IsType<Person[]>(People.FindAll());
        }

        [Fact]
        public void IfPersonArrayDoesNotContainPersonWithIdReturnShouldBeNull()
        {
            Person personThatShouldBeNull = People.FindById(1000000);
            Assert.Null(personThatShouldBeNull);
        }

        [Fact]
        public void IfPersonArrayContainsPersonWithIdReturnedPersonShouldNotBeNull()
        {
            Person personThatShouldNotBeNull = People.FindById(1);
            Assert.NotNull(personThatShouldNotBeNull);
        }

        [Fact]
        public void CreatedPersonShouldBeAddedToArrayAndReturned()
        {
            int personIdOne = 1;
            string firstNameOne = "FirstNameOne";
            string lastNameOne = "LastNameOne";
            Person personOne = People.CreateAndAddNewPersonToArrayThenReturnPerson(firstNameOne, lastNameOne);

            Assert.Equal(personIdOne, personOne.PersonId);
            Assert.Equal(firstNameOne, personOne.FirstName);
            Assert.Equal(lastNameOne, personOne.LastName);
        }

        [Fact]
        public void CallingClearMethodShouldResultInAnEmptyArray()
        {
            People.Clear();
            Assert.Null(People.FindAll()[0]);
        }
    }
}
