using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieDatabase.Exceptions;

namespace MovieDatabase.Utils
{
    public class DatabaseUtils
    {
        // Define the connection string and instance lock.
        private static readonly object _instanceLockObj = new object();
        private static readonly string _databasePath = @"../../../MovieData.db";
        private static readonly string _connectionString = $"Data Source={_databasePath};Version3";
        // Define the DatabaseUtils instance and its connection
        private static DatabaseUtils? _instance;
        private SQLiteConnection _connection;

        /// <summary>
        /// Private constructor for the DatabaseUtils class to
        /// stop the creation of multiple instances of DatabaseUtils.
        /// </summary>
        private DatabaseUtils()
        {
            if (ExistsDatabase())
            {
                Connect();
            }
            else
            {
                InitializeDatabase();
            }
        }

        /// <summary>
        /// Gets the current instance of the DatabaseUtils or
        /// creates one if it does not exist.
        /// </summary>
        /// <returns>The instance of DatabaseUtils</returns>
        public static DatabaseUtils GetInstance()
        {
            if (_instance == null)
            {
                lock (_instanceLockObj)
                {
                    if (_instance == null)
                    {
                        _instance = new DatabaseUtils();
                    }
                }
            }
            return _instance;
        }

        /// <summary>
        /// Check whether the database file exists.
        /// </summary>
        /// <returns>A boolean indicating whether the database file exists.</returns>
        private static bool ExistsDatabase()
        {
            return File.Exists(_databasePath);
        }

        /// <summary>
        /// Initializes a blank database containing the tables
        /// defined in the ER diagram.
        /// </summary>
        private void InitializeDatabase()
        {
            try
            {
                // Create the database file and connect to it
                File.Create(_databasePath).Close();
                Connect();
                // TODO: Create the database tables
            } 
            catch (IOException ex)
            {
                throw new DatabaseInitializationException("Error: could not create the database file: " + ex.Message);
            }
            
        }

        private void Connect()
        {
            // Connect to the database
            _connection = new SQLiteConnection(_connectionString);
            _connection.Open();
        }

        /// <summary>
        /// Close the connection to the DatabaseUtils class and remove
        /// the current instance of DatabaseUtils.
        /// </summary>
        public void CloseConnection()
        {
            _connection.Close();
            _instance = null;
        }
    }
}
