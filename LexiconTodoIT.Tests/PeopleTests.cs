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
        public void CreatedPersonShouldBeAddedToArrayAndReturned()
        {
            People.Clear();

            int personId = 1;
            string firstNameOne = "FirstNameTwo";
            string lastNameOne = "LastNameTwo";
            Person personOne = People.CreateAndAddNewPersonToArrayThenReturnPerson(firstNameOne, lastNameOne);

            Assert.Equal(personId, personOne.PersonId);
            Assert.Equal(firstNameOne, personOne.FirstName);
            Assert.Equal(lastNameOne, personOne.LastName);
        }


        [Fact]
        public void IfPersonArrayContainsPersonWithIdReturnedPersonShouldNotBeNull()
        {
           
            Person personThatShouldNotBeNull = People.FindById(1);

            Assert.NotNull(personThatShouldNotBeNull);
        }

        [Fact]
        public void CallingClearMethodShouldResultInAnEmptyArray()
        {
            People.Clear();
            Assert.Null(People.FindAll()[0]);
        }
    }
}
