using System;
using System.Collections.Generic;
using System.Text;

namespace LexiconTodoIT.Model
{
    public class Person
    {
        private readonly int personId;
        private string firstName;
        private string lastName;

        public Person(int personId, string firstName, string lastName)
        {
            this.personId = personId;
            FirstName = firstName;
            LastName = lastName;
        }

        public int PersonId { get { return personId; } }


        //Name input cannot be empty
        public string FirstName
        { 
            get { return firstName; }
            set 
            { 
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException($"'{nameof(firstName)}' cannot be null or empty.");
                firstName = value;
            } 
        }

        //Name input cannot be empty
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException($"'{nameof(lastName)}' cannot be null or empty.");
                lastName = value;
            }
        }


    }
}
