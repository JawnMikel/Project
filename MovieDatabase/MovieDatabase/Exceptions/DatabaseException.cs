using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.Exceptions
{
    /// <summary>
    /// DatabaseException is used to represent exceptions that might be
    /// thrown for any unsuccessful database operation.
    /// </summary>
    public class DatabaseException : Exception
    {
        public DatabaseException(string? message) : base(message)
        {
        }
    }
}
