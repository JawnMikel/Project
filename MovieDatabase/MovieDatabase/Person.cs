using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieDatabase.Utils;

namespace MovieDatabase
{
    /// <summary>
    /// Person is used as a base class for representing people.
    /// </summary>
    public abstract class Person 
    {
        private string _firstName;
        private string _lastName;

        public string FirstName
        {
            get => _firstName;
            set
            {
                if (Util.ValidateNameFormat(value))
                {
                    throw new ArgumentException("The first name's format is invalid.");
                }
                _firstName = value;
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                if (Util.ValidateNameFormat(value))
                {
                    throw new ArgumentException("The last name's format is invalid.");
                }
                _lastName = value;
            }
        }

        /// <summary>
        /// All argument constructor for a person object.
        /// </summary>
        /// <param name="firstName">The first name of the person.</param>
        /// <param name="lastName">The last name of the person.</param>
        public Person(string firstName, string lastName)
        { 
            FirstName = Util.ToPascalCase(firstName);
            LastName = Util.ToPascalCase(lastName);
        }

        /// <summary>
        /// Checks whether an object is equal to this person.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>A boolean indicating whether the object provided is equal to this person.</returns>
        public override bool Equals(object? obj)
        {
            return obj is Person person &&
                   FirstName == person.FirstName &&
                   LastName == person.LastName;
        }

        /// <summary>
        /// Generate a hashcode for this person.
        /// </summary>
        /// <returns>The hashcode of this person.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName);
        }
    }
}
