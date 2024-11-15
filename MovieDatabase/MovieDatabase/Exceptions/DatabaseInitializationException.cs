using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.Exceptions
{
    /// <summary>
    /// DatabaseInitializationException is used to represent exceptions thrown
    /// when attempting to initialize (create) the database.
    /// </summary>
    public class DatabaseInitializationException : DatabaseException
    {
        public DatabaseInitializationException(string? message) : base(message)
        {
        }
    }
}
