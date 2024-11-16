using MovieDatabase.Exceptions;
using System.Data.SQLite;

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
        private static readonly string _connectionString = $"Data Source={_databasePath};Version=3";
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
                // Create the main tables
                CreateUserTable();
                CreatePaymentTable();
                CreateMovieTable();
                CreateTVShowTable();
                CreateEpisodeTable();
                CreateGenreTable();
                CreateActorTable();
                CreateReviewTable();
                CreateDirectorTable();
                // Create the many-to-many tables
                CreateWatchListMovieTable();
                CreateWatchListTVShowTable();
                // Create the media genre tables
                CreateMovieGenreTable();
                CreateTVShowGenreTable();
                CreateEpisodeGenreTable();
                // Create the media actor tables
                CreateMovieActorTable();
                CreateTVShowActorTable();
                CreateEpisodeActorTable();
                // Create the media review tables
                CreateMovieReviewTable();
                CreateTVShowReviewTable();
                CreateEpisodeReviewTable();
                // Create the media director tables
                CreateMovieDirectorTable();
                CreateTVShowDirectorTable();
                CreateEpisodeDirectorTable();
                // Create the director/actor review tables
                CreateDirectorReviewTable();
                CreateActorReviewTable();
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
        /// Create the payment table.
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
                                    CONSTRAINT chk_CardExpirationDateFormat CHECK (CardExpirationDate LIKE '____-__-00'),
                                    CONSTRAINT chk_CardExpirationDateFuture CHECK (CardExpirationDate > DATE('now')),
                                    CONSTRAINT fk_UserID FOREIGN KEY (UserID) REFERENCES user(UserID)
                                );
                                """;
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Create the genre table.
        /// </summary>
        private void CreateGenreTable()
        {
            const string SQL = """
                                CREATE TABLE IF NOT EXISTS genre (
                                    GenreID INTEGER PRIMARY KEY,
                                    GenreName TEXT UNIQUE NOT NULL
                                );
                                """;
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Create the tv show table.
        /// </summary>
        private void CreateTVShowTable()
        {
            const string SQL = """
                                CREATE TABLE IF NOT EXISTS tvshow (
                                    TVShowID INTEGER PRIMARY KEY,
                                    Title TEXT NOT NULL,
                                    ReleaseDate TEXT NOT NULL,
                                    Synopsis TEXT NOT NULL,
                                    CONSTRAINT chk_ReleaseDateFormat CHECK (ReleaseDate LIKE '____-__-__')
                                );
                                """;
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Create the episode table.
        /// </summary>
        private void CreateEpisodeTable()
        {
            const string SQL = """
                                CREATE TABLE IF NOT EXISTS episode (
                                    EpisodeID INTEGER PRIMARY KEY,
                                    Title TEXT NOT NULL,
                                    ReleaseDate TEXT NOT NULL,
                                    Synopsis TEXT NOT NULL,
                                    Duration INTEGER NOT NULL,
                                    SeasonNumber INTEGER NOT NULL,
                                    EpisodeNumber INTEGER NOT NULL,
                                    TVShowID INTEGER NOT NULL,
                                    CONSTRAINT chk_ReleaseDateFormat CHECK (ReleaseDate LIKE '____-__-__'),
                                    CONSTRAINT chk_DurationPositive CHECK (Duration > 0),
                                    CONSTRAINT chk_SeasonNumber CHECK (SeasonNumber > 0),
                                    CONSTRAINT chk_EpisodeNumber CHECK (EpisodeNumber > 0),
                                    CONSTRAINT fk_TVShowID FOREIGN KEY (TVShowID) REFERENCES tvshow(TVShowID)
                                );
                                """;
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Create the movie table.
        /// </summary>
        private void CreateMovieTable()
        {
            const string SQL = """
                                CREATE TABLE IF NOT EXISTS movie (
                                    MovieID INTEGER PRIMARY KEY,
                                    Title TEXT NOT NULL,
                                    ReleaseDate TEXT NOT NULL,
                                    Duration INTEGER NOT NULL,
                                    Synopsis TEXT NOT NULL,
                                    ImageLink TEXT NOT NULL,
                                    CONSTRAINT chk_ReleaseDateFormat CHECK (ReleaseDate LIKE '____-__-__'),
                                    CONSTRAINT chk_DurationPositive CHECK (Duration > 0)
                                );
                                """;
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Create the actor table.
        /// </summary>
        private void CreateActorTable()
        {
            const string SQL = """
                                CREATE TABLE IF NOT EXISTS actor (
                                    ActorID INTEGER PRIMARY KEY,
                                    FirstName TEXT NOT NULL,
                                    LastName TEXT NOT NULL
                                );
                                """;
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Create the director table.
        /// </summary>
        private void CreateDirectorTable()
        {
            const string SQL = """
                                CREATE TABLE IF NOT EXISTS director (
                                    DirectorID INTEGER PRIMARY KEY,
                                    FirstName TEXT NOT NULL,
                                    LastName TEXT NOT NULL
                                );
                                """;
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Create the review table.
        /// </summary>
        private void CreateReviewTable()
        {
            const string SQL = """
                                CREATE TABLE IF NOT EXISTS review (
                                    ReviewID INTEGER PRIMARY KEY,
                                    Comment TEXT NOT NULL,
                                    Rating REAL NOT NULL,
                                    UserID INTEGER NOT NULL,
                                    CONSTRAINT chk_RatingRange CHECK (Rating = ROUND(Rating, 1)),
                                    CONSTRAINT fk_UserID FOREIGN KEY (UserID) REFERENCES user(UserID)
                                );
                                """;
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Create the watch list movie table.
        /// </summary>
        private void CreateWatchListMovieTable()
        {
            const string SQL = """
                                CREATE TABLE IF NOT EXISTS watchlistmovie (
                                    MovieID INTEGER,
                                    UserID INTEGER,
                                    CONSTRAINT pk_Composite PRIMARY KEY (MovieID, UserID)
                                );
                                """;
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Create the watch list tv show table.
        /// </summary>
        private void CreateWatchListTVShowTable()
        {
            const string SQL = """
                                CREATE TABLE IF NOT EXISTS watchlisttvshow (
                                    TVShowID INTEGER,
                                    UserID INTEGER,
                                    CONSTRAINT pk_Composite PRIMARY KEY (TVShowID, UserID)
                                );
                                """;
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Create the movie genre table.
        /// </summary>
        private void CreateMovieGenreTable()
        {
            const string SQL = """
                                CREATE TABLE IF NOT EXISTS moviegenre (
                                    MovieID INTEGER,
                                    GenreID INTEGER,
                                    CONSTRAINT pk_Composite PRIMARY KEY (MovieID, GenreID)
                                );
                                """;
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Create the tv show genre table.
        /// </summary>
        private void CreateTVShowGenreTable()
        {
            const string SQL = """
                                CREATE TABLE IF NOT EXISTS tvshowgenre (
                                    TVShowID INTEGER,
                                    GenreID INTEGER,
                                    CONSTRAINT pk_Composite PRIMARY KEY (TVShowID, GenreID)
                                );
                                """;
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Create the episode genre table.
        /// </summary>
        private void CreateEpisodeGenreTable()
        {
            const string SQL = """
                                CREATE TABLE IF NOT EXISTS episodegenre (
                                    EpisodeID INTEGER,
                                    GenreID INTEGER,
                                    CONSTRAINT pk_Composite PRIMARY KEY (EpisodeID, GenreID)
                                );
                                """;
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Create movie actor table.
        /// </summary>
        private void CreateMovieActorTable()
        {
            const string SQL = """
                                CREATE TABLE IF NOT EXISTS movieactor (
                                    MovieID INTEGER,
                                    ActorID INTEGER,
                                    CONSTRAINT pk_Composite PRIMARY KEY (MovieID, ActorID)
                                );
                                """;
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Create the tv show actor table.
        /// </summary>
        private void CreateTVShowActorTable()
        {
            const string SQL = """
                                CREATE TABLE IF NOT EXISTS tvshowactor (
                                    TVShowID INTEGER,
                                    ActorID INTEGER,
                                    CONSTRAINT pk_Composite PRIMARY KEY (TVShowID, ActorID)
                                );
                                """;
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Create the episode actor table.
        /// </summary>
        private void CreateEpisodeActorTable()
        {
            const string SQL = """
                                CREATE TABLE IF NOT EXISTS episodeactor (
                                    EpisodeID INTEGER,
                                    ActorID INTEGER,
                                    CONSTRAINT pk_Composite PRIMARY KEY (EpisodeID, ActorID)
                                );
                                """;
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Create the movie review table.
        /// </summary>
        private void CreateMovieReviewTable()
        {
            const string SQL = """
                                CREATE TABLE IF NOT EXISTS moviereview (
                                    MovieID INTEGER,
                                    ReviewID INTEGER,
                                    CONSTRAINT pk_Composite PRIMARY KEY (MovieID, ReviewID)
                                );
                                """;
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Create the tv show review table.
        /// </summary>
        private void CreateTVShowReviewTable()
        {
            const string SQL = """
                                CREATE TABLE IF NOT EXISTS tvshowreview (
                                    TVShowID INTEGER,
                                    ReviewID INTEGER,
                                    CONSTRAINT pk_Composite PRIMARY KEY (TVShowID, ReviewID)
                                );
                                """;
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Create the episode review table.
        /// </summary>
        private void CreateEpisodeReviewTable()
        {
            const string SQL = """
                                CREATE TABLE IF NOT EXISTS episodereview (
                                    EpisodeID INTEGER,
                                    ReviewID INTEGER,
                                    CONSTRAINT pk_Composite PRIMARY KEY (EpisodeID, ReviewID)
                                );
                                """;
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Create the movie director table.
        /// </summary>
        private void CreateMovieDirectorTable()
        {
            const string SQL = """
                                CREATE TABLE IF NOT EXISTS moviedirector (
                                    MovieID INTEGER,
                                    DirectorID INTEGER,
                                    CONSTRAINT pk_Composite PRIMARY KEY (MovieID, DirectorID)
                                );
                                """;
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Create the tv show director table
        /// </summary>
        private void CreateTVShowDirectorTable()
        {
            const string SQL = """
                                CREATE TABLE IF NOT EXISTS tvshowdirector (
                                    TVShowID INTEGER,
                                    DirectorID INTEGER,
                                    CONSTRAINT pk_Composite PRIMARY KEY (TVShowID, DirectorID)
                                );
                                """;
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Create the episode director table.
        /// </summary>
        private void CreateEpisodeDirectorTable()
        {
            const string SQL = """
                                CREATE TABLE IF NOT EXISTS episodedirector (
                                    EpisodeID INTEGER,
                                    DirectorID INTEGER,
                                    CONSTRAINT pk_Composite PRIMARY KEY (EpisodeID, DirectorID)
                                );
                                """;
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Create the actor review table.
        /// </summary>
        private void CreateActorReviewTable()
        {
            const string SQL = """
                                CREATE TABLE IF NOT EXISTS actorreview (
                                    ActorID INTEGER,
                                    ReviewID INTEGER,
                                    CONSTRAINT pk_Composite PRIMARY KEY (ActorID, ReviewID)
                                );
                                """;
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Create the director review table.
        /// </summary>
        private void CreateDirectorReviewTable()
        {
            const string SQL = """
                                CREATE TABLE IF NOT EXISTS directorreview (
                                    DirectorID INTEGER,
                                    ReviewID INTEGER,
                                    CONSTRAINT pk_Composite PRIMARY KEY (DirectorID, ReviewID)
                                );
                                """;
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}
