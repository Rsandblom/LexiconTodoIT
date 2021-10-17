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
            People.Clear();
            PersonSequencer.reset();

            int lenghtOfArray = 0;
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
            PersonSequencer.reset();

            int personId = 1;
            string firstNameOne = "FirstNameOne";
            string lastNameOne = "LastNameOne";
            Person personOne = People.CreateAndAddNewPersonToArrayThenReturnPerson(firstNameOne, lastNameOne);

            Assert.Equal(personId, personOne.PersonId);
            Assert.Equal(firstNameOne, personOne.FirstName);
            Assert.Equal(lastNameOne, personOne.LastName);
        }


        [Fact]
        public void IfPersonArrayContainsPersonWithIdReturnedPersonShouldNotBeNull()
        {
            People.Clear();
            PersonSequencer.reset();

            string firstNameOne = "FirstNameOne";
            string lastNameOne = "LastNameOne";
            Person personOne = People.CreateAndAddNewPersonToArrayThenReturnPerson(firstNameOne, lastNameOne);
            Person personThatShouldNotBeNull = People.FindById(1);

            Assert.NotNull(personThatShouldNotBeNull);
        }

        [Fact]
        public void CallingClearMethodShouldResultInAnEmptyArray()
        {
            People.Clear();
            Assert.Empty(People.FindAll());
        }

        [Fact]
        public void RemoveObjectFromArrayWithId()
        {
            People.Clear();
            PersonSequencer.reset();

            string firstNameOne = "FirstNameOne";
            string lastNameOne = "LastNameOne";
            Person personOne = People.CreateAndAddNewPersonToArrayThenReturnPerson(firstNameOne, lastNameOne);

            string firstNameTwo = "FirstNameTwo";
            string lastNameTwo = "LastNameTwo";
            Person personTwo = People.CreateAndAddNewPersonToArrayThenReturnPerson(firstNameTwo, lastNameTwo);

            string firstNameThree = "FirstNameThree";
            string lastNameThree = "LastNameThree";
            Person personThree = People.CreateAndAddNewPersonToArrayThenReturnPerson(firstNameThree, lastNameThree);


            People.RemovePerson(personTwo.PersonId);

            Person[] removePersonIdTwoArray = People.FindAll();

            Assert.Equal(2, removePersonIdTwoArray.Length);
            Assert.Equal(personOne.PersonId, removePersonIdTwoArray[0].PersonId);
            Assert.Equal(personThree.PersonId, removePersonIdTwoArray[1].PersonId);

        }
    }
}
