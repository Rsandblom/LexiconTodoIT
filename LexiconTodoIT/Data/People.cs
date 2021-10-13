using LexiconTodoIT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LexiconTodoIT.Data
{
    public class People
    {
        private static Person[] personArray = new Person[0];

        public static int Size()
        {
            return personArray.Length;
        }

        public static Person[] FindAll()
        {
            return personArray;
        }

        public static Person FindById(int personId)
        {
            Person person = personArray.Where(p => p.PersonId == personId).FirstOrDefault();
            return person;
        }

        public static Person CreateAndAddNewPersonToArrayThenReturnPerson(string firstName, string lastName)
        {
            int personId = PersonSequencer.nextPersonId();
            Person newPerson = new Person(personId, firstName, lastName);
            Array.Resize(ref personArray, personArray.Length + 1);
            personArray[personArray.Length - 1] = newPerson;

            return newPerson;
        }
        public static void Clear()
        {
            Array.Clear(personArray, 0, personArray.Length);
        }
    }
}
