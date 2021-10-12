using System;
using System.Collections.Generic;
using System.Text;

namespace LexiconTodoIT.Data
{
    public class PersonSequencer
    {
        private static int personId;

        public static int PersonId { get {return personId; } }

        public static int nextPersonId()
        {
            personId++;
            return PersonId;
        }

        public static void reset()
        {
            personId = 0;
        }

    }
}
