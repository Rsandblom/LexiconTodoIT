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
            TodoItems.Clear();
            TodoSequencer.reset();

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
            TodoItems.Clear();
            TodoSequencer.reset();

            int todoId = 1;
            string description = "TheDescription";
            Todo todoOne = TodoItems.CreateAndAddNewTodoToArrayThenReturnTodo(description);

            Assert.Equal(todoId, todoOne.TodoId);
            Assert.Equal(description, todoOne.Description);
        }

        [Fact]
        public void IfTodoArrayContainsTodoWithIdReturnedTodoShouldNotBeNull()
        {
            TodoItems.Clear();
            TodoSequencer.reset();

            string description = "TheDescription";
            Todo todoOne = TodoItems.CreateAndAddNewTodoToArrayThenReturnTodo(description);
            Todo todoThatShouldNotBeNull = TodoItems.FindById(1);

            Assert.NotNull(todoThatShouldNotBeNull);
        }

        [Fact]
        public void CallingClearMethodShouldResultInAnEmptyArray()
        {
            TodoItems.Clear();
            Assert.Empty(TodoItems.FindAll());
        }

        [Fact]
        public void FindAllTododsWithMatchingDoneStatus()
        {
            TodoItems.Clear();
            TodoSequencer.reset();

            string descriptionOne = "TheDescriptionOne";
            Todo todoOne = TodoItems.CreateAndAddNewTodoToArrayThenReturnTodo(descriptionOne);
            todoOne.Done = false;

            string descriptionTwo = "TheDescriptionTwo";
            Todo todoTwo = TodoItems.CreateAndAddNewTodoToArrayThenReturnTodo(descriptionTwo);
            todoTwo.Done = true;

            string descriptionThree = "TheDescriptionThree";
            Todo todoThree = TodoItems.CreateAndAddNewTodoToArrayThenReturnTodo(descriptionThree);
            todoThree.Done = false;

            Todo[] doneStatusFalseArray = TodoItems.FindByDoneStatus(false);

            Assert.Equal(2,doneStatusFalseArray.Length);
            Assert.False(doneStatusFalseArray[0].Done);
            Assert.False(doneStatusFalseArray[1].Done);

            Todo[] doneStatusTrueArray = TodoItems.FindByDoneStatus(true);

            Assert.Single(doneStatusTrueArray);
            Assert.True(doneStatusTrueArray[0].Done);
        }

        [Fact]
        public void FindAllTododsWithMatchingAsigneePersonId()
        {
            TodoItems.Clear();
            TodoSequencer.reset();
            People.Clear();
            PersonSequencer.reset();

            string firstNameOne = "FirstNameOne";
            string lastNameOne = "LastNameOne";
            Person personOne = People.CreateAndAddNewPersonToArrayThenReturnPerson(firstNameOne, lastNameOne);
            string descriptionOne = "TheDescriptionOne";
            Todo todoOne = TodoItems.CreateAndAddNewTodoToArrayThenReturnTodo(descriptionOne);
            todoOne.Assignee = personOne;



            string firstNameTwo = "FirstNameTwo";
            string lastNameTwo = "LastNameTwo";
            Person personTwo = People.CreateAndAddNewPersonToArrayThenReturnPerson(firstNameTwo, lastNameTwo);
            string descriptionTwo = "TheDescriptionTwo";
            Todo todoTwo = TodoItems.CreateAndAddNewTodoToArrayThenReturnTodo(descriptionTwo);
            todoTwo.Assignee = personTwo;

            string descriptionThree = "TheDescriptionThree";
            Todo todoThree = TodoItems.CreateAndAddNewTodoToArrayThenReturnTodo(descriptionThree);
            todoThree.Assignee = personTwo;

            Todo[] matchingTwoAssigneePersonIdArray = TodoItems.FindByAssignees(personTwo.PersonId);

            Assert.Equal(2, matchingTwoAssigneePersonIdArray.Length);
            Assert.Equal(personTwo.PersonId, matchingTwoAssigneePersonIdArray[0].Assignee.PersonId);
            Assert.Equal(personTwo.PersonId, matchingTwoAssigneePersonIdArray[1].Assignee.PersonId);


            Todo[] matchingOneAssigneePersonIdArray = TodoItems.FindByAssignees(personOne.PersonId);

            Assert.Single(matchingOneAssigneePersonIdArray);
            Assert.Equal(personOne.PersonId, matchingOneAssigneePersonIdArray[0].Assignee.PersonId);
        }

        [Fact]
        public void FindAllTododsWithMatchingAsignee()
        {
            TodoItems.Clear();
            TodoSequencer.reset();
            People.Clear();
            PersonSequencer.reset();

            string firstNameOne = "FirstNameOne";
            string lastNameOne = "LastNameOne";
            Person personOne = People.CreateAndAddNewPersonToArrayThenReturnPerson(firstNameOne, lastNameOne);
            string descriptionOne = "TheDescriptionOne";
            Todo todoOne = TodoItems.CreateAndAddNewTodoToArrayThenReturnTodo(descriptionOne);
            todoOne.Assignee = personOne;



            string firstNameTwo = "FirstNameTwo";
            string lastNameTwo = "LastNameTwo";
            Person personTwo = People.CreateAndAddNewPersonToArrayThenReturnPerson(firstNameTwo, lastNameTwo);
            string descriptionTwo = "TheDescriptionTwo";
            Todo todoTwo = TodoItems.CreateAndAddNewTodoToArrayThenReturnTodo(descriptionTwo);
            todoTwo.Assignee = personTwo;

            string descriptionThree = "TheDescriptionThree";
            Todo todoThree = TodoItems.CreateAndAddNewTodoToArrayThenReturnTodo(descriptionThree);
            todoThree.Assignee = personTwo;

            Todo[] matchingTwoAssigneeArray = TodoItems.FindByAssignees(personTwo);

            Assert.Equal(2, matchingTwoAssigneeArray.Length);
            Assert.Equal(personTwo.PersonId, matchingTwoAssigneeArray[0].Assignee.PersonId);
            Assert.Equal(personTwo.PersonId, matchingTwoAssigneeArray[1].Assignee.PersonId);


            Todo[] matchingOneAssigneeArray = TodoItems.FindByAssignees(personOne);

            Assert.Single(matchingOneAssigneeArray);
            Assert.Equal(personOne.PersonId, matchingOneAssigneeArray[0].Assignee.PersonId);
        }

        [Fact]
        public void FindAllTododsWithoutAssignee()
        {
            TodoItems.Clear();
            TodoSequencer.reset();
            People.Clear();
            PersonSequencer.reset();

            string firstNameOne = "FirstNameOne";
            string lastNameOne = "LastNameOne";
            Person personOne = People.CreateAndAddNewPersonToArrayThenReturnPerson(firstNameOne, lastNameOne);
            string descriptionOne = "TheDescriptionOne";
            Todo todoOne = TodoItems.CreateAndAddNewTodoToArrayThenReturnTodo(descriptionOne);
            todoOne.Assignee = personOne;



            string firstNameTwo = "FirstNameTwo";
            string lastNameTwo = "LastNameTwo";
            Person personTwo = People.CreateAndAddNewPersonToArrayThenReturnPerson(firstNameTwo, lastNameTwo);
            string descriptionTwo = "TheDescriptionTwo";
            Todo todoTwo = TodoItems.CreateAndAddNewTodoToArrayThenReturnTodo(descriptionTwo);

            string descriptionThree = "TheDescriptionThree";
            Todo todoThree = TodoItems.CreateAndAddNewTodoToArrayThenReturnTodo(descriptionThree);
            todoThree.Assignee = personTwo;

            string descriptionFour = "TheDescriptionFour";
            Todo todoFour = TodoItems.CreateAndAddNewTodoToArrayThenReturnTodo(descriptionFour);

            Todo[] matchingTwoUnAssignedArray = TodoItems.FindByUnassignedTodoItems();

            Assert.Equal(2, matchingTwoUnAssignedArray.Length);
            Assert.Equal(todoTwo.TodoId, matchingTwoUnAssignedArray[0].TodoId);
            Assert.Equal(todoFour.TodoId, matchingTwoUnAssignedArray[1].TodoId);

        }
    }
}
