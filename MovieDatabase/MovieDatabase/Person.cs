using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase
{
    public abstract class Person 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        /// <summary>
        /// All argument constructor for a person object.
        /// </summary>
        /// <param name="firstName">The first name of the person.</param>
        /// <param name="lastName">The last name of the person.</param>
        protected Person(string firstName, string lastName)
        {
            FirstName = Utils.Util.ToPascaleCase(firstName);
            LastName = Utils.Util.ToPascaleCase(lastName);
        }
    }
}
