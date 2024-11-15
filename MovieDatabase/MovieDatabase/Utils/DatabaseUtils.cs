using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MovieDatabase.Exceptions;

namespace MovieDatabase.Utils
{
    /// <summary>
    /// DatabaseUtils class is used to keep a connection to
    /// the movie database, and to fetch/insert data into it.
    /// </summary>
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

        /// <summary>
        /// Connect to the database
        /// </summary>
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

        /// <summary>
        /// Create the user table.
        /// </summary>
        private void CreateUserTable()
        {
            const string SQL = """
                                CREATE TABLE IF NOT EXISTS user (
                                    UserID INTEGER PRIMARY KEY,
                                    FirstName TEXT NOT NULL,
                                    LastName TEXT NOT NULL,
                                    UserName TEXT UNIQUE NOT NULL,
                                    Password TEXT NOT NULL
                                );
                                """;
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Create the payment table
        /// </summary>
        private void CreatePaymentTable()
        {
            const string SQL = """
                                CREATE TABLE IF NOT EXISTS payment (
                                    PaymentID INTEGER PRIMARY KEY,
                                    CardHolderName TEXT NOT NULL,
                                    CreditCardNumber TEXT NOT NULL,
                                    CreditCardCVV TEXT NOT NULL,
                                    CardExpirationDate TEXT NOT NULL,
                                    UserID INTEGER NOT NULL,
                                    CONSTRAINT chk_CardExpirationDate CHECK ()
                                );
                                """;
        }

        private void CreateGenreTable()
        {
        
        }

        private void CreateTVShowTable()
        {
        
        }

        private void CreateEpisodeTable()
        {
        
        }

        private void CreateMovieTable()
        {
        
        }

        private void CreateActorTable()
        {

        }

        private void CreateDirectorTable()
        {
        
        }

        private void CreateReviewTable()
        {
        
        }

        private void CreateWatchListMovieTable()
        {
        
        }

        private void CreateWatchListTVShowTable()
        {
        
        }

        private void CreateMovieGenreTable()
        {
        
        }

        private void CreateTVShowGenreTable()
        {
        
        }

        private void CreateEpisodeGenreTable()
        {
        
        }

        private void CreateMovieActorTable()
        {
        
        }

        private void CreateTVShowActorTable()
        {
        
        }

        private void CreateEpisodeActorTable()
        {
        
        }

        private void CreateMovieReviewTable()
        {
        
        }

        private void CreateTVShowReviewTable()
        {
        
        }

        private void CreateEpisodeReviewTable()
        {

        }

        private void CreateMovieDirectorTable()
        {
        
        }

        private void CreateTVShowDirectorTable()
        {
        
        }

        private void CreateEpisodeDirectorTable()
        {

        }

        private void CreateActorReviewTable()
        {
        
        }

        private void CreateDirectorReviewTable()
        {
        
        }
    }
}
