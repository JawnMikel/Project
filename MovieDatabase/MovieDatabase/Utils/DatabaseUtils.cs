using Microsoft.VisualBasic.ApplicationServices;
using MovieDatabase.Exceptions;
using System.ComponentModel;
using System.Data.SqlClient;
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
        /// Insert a director into the director table.
        /// </summary>
        /// <param name="director">The director to insert.</param>
        /// <exception cref="ArgumentNullException">Exception thrown when the director argument is null.</exception>
        /// <returns>The DirectorID of the director inserted.</returns>
        public int InsertDirector(Director director)
        {
            // Validate the parameter
            if (director == null)
            {
                throw new ArgumentNullException("The director argument cannot be null.");
            }
            const string SQL = """
                                INSERT INTO director (FirstName, LastName) VALUES (@FirstName, @LastName);
                                """;
            const string PK_SQL = """
                                   SELECT DirectorID FROM director WHERE rowid = last_insert_rowid();
                                   """;
            int id = -1;
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            using (SQLiteCommand pkCmd = new SQLiteCommand(PK_SQL, _connection))
            {
                // Form the SQL query using data from the user
                cmd.Parameters.AddWithValue("@FirstName", director.FirstName);
                cmd.Parameters.AddWithValue("@LastName", director.LastName);
                // Execute the SQL
                cmd.ExecuteNonQuery();
                // Get the PK
                id = Convert.ToInt32(pkCmd.ExecuteScalar());
            }
            return id;
        }

        /// <summary>
        /// Insert a user into the user table.
        /// </summary>
        /// <param name="user">The user to insert.</param>
        /// <exception cref="ArgumentNullException">Thrown when the user provided is null.</exception>
        /// <returns>The UserId of the user inserted.</returns>
        public int InsertUser(User user)
        {
            // Validate the parameter
            if (user == null)
            {
                throw new ArgumentNullException("The user argument cannot be null.");
            }
            // Define the insert statement
            const string SQL = """
                                INSERT INTO user (FirstName, LastName, UserName, Password)
                                VALUES (@FirstName, @LastName, @UserName, @Password);
                                """;
            const string PK_SQL = """
                                   SELECT UserID FROM user WHERE rowid = last_insert_rowid();
                                   """;
            int id = -1;
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            using (SQLiteCommand pkCmd = new SQLiteCommand(PK_SQL, _connection))
            {
                // Form the SQL query using data from the user
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@UserName", user.UserName);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                // Execute the SQL
                cmd.ExecuteNonQuery();
                // Get the PK
                id = Convert.ToInt32(pkCmd.ExecuteScalar());
            }
            return id;
        }

        /// <summary>
        /// Insert a watchlisttvshow entry into the watchlisttvshow table.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        /// <param name="tvShowId">The tv show ID.</param>
        public void InsertWatchListTVShow(int userId, int tvShowId)
        {
            // Define the insert statement
            const string SQL = """
                                INSERT INTO watchlisttvshow (TVShowID, UserID) VALUES (@TVShowID, @UserID);
                                """;
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                // Form the SQL query using data from the user
                cmd.Parameters.AddWithValue("@TVShowID", tvShowId);
                cmd.Parameters.AddWithValue("@UserID", userId);
                // Execute the SQL
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Insert a watchlistmovie entry into the watchlistmovie table.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="movieId"></param>
        public void InsertWatchListMovie(int userId, int movieId)
        {
            // Define the insert statement
            const string SQL = """
                                INSERT INTO watchlistmovie (MovieID, UserID) VALUES (@MovieID, @UserID);
                                """;
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                // Form the SQL query using data from the user
                cmd.Parameters.AddWithValue("@MovieID", movieId);
                cmd.Parameters.AddWithValue("@UserID", userId);
                // Execute the SQL
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Insert a payment into the database.
        /// </summary>
        /// <param name="payment">The payment object.</param>
        /// <param name="userID">The user ID of the user making the payment.</param>
        /// <exception cref="ArgumentNullException">Thrown when the payment object is null.</exception>
        public void InsertPayment(Payment payment, int userID)
        {
            // Validate the parameter
            if (payment == null)
            {
                throw new ArgumentNullException("The payment argument cannot be null.");
            }
            // Define the insert statement
            const string SQL = """
                               INSERT INTO payment (CardHolderName, CreditCardNumber, CreditCardCVV, 
                                 CardExpirationDate, PaymentDate, UserID)
                               VALUES (@Name, @Number, @CVV, @ExpDate, @PayDate, @UserID);
                               """;
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                // Form the SQL query using data from the user
                cmd.Parameters.AddWithValue("@Name", payment.CardHolderName);
                cmd.Parameters.AddWithValue("@Number", payment.CreditCardNum);
                cmd.Parameters.AddWithValue("@CVV", payment.CVV);
                cmd.Parameters.AddWithValue("@ExpDate", payment.ExpiryDate);
                cmd.Parameters.AddWithValue("@PayDate", DateTime.Now.ToString());
                cmd.Parameters.AddWithValue("@UserID", userID);
                // Execute the SQL
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Insert a movie into the movie table.
        /// </summary>
        /// <param name="movie">The movie to isnert.</param>
        /// <returns>The MovieID of the movie inserted.</returns>
        public int InsertMovie(Movie movie)
        {
            // Validate the parameter
            if (movie == null)
            {
                throw new ArgumentNullException("The movie argument cannot be null.");
            }
            // Define the insert statement
            const string SQL = """
                                INSERT INTO movie (Title, ReleaseDate, Duration, Synopsis, ImageLink)
                                VALUES (@Title, @ReleaseDate, @Duration, @Synopsis, @ImageLink);
                                """;
            const string PK_SQL = """
                                   SELECT MovieID FROM movie WHERE rowid = last_insert_rowid();
                                   """;
            int id = -1;
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            using (SQLiteCommand pkCmd = new SQLiteCommand(PK_SQL, _connection))
            {
                // Form the SQL statement using data from the user
                cmd.Parameters.AddWithValue("@Title", movie.Title);
                cmd.Parameters.AddWithValue("@ReleaseDate", movie.ReleaseDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Duration", movie.Duration);
                cmd.Parameters.AddWithValue("@Synopsis", movie.Sysnopsis);
                cmd.Parameters.AddWithValue("@ImageLink", movie.ImageLink);
                // Execute the SQL query using data from the user
                cmd.ExecuteNonQuery();
                // Get the PK
                id = Convert.ToInt32(pkCmd.ExecuteScalar());
            }
            return id;
        }

        /// <summary>
        /// Insert a tv show into the tvshow table.
        /// </summary>
        /// <param name="tvShow">The tv show to insert.</param>
        /// <returns>The TVShowID of the tv show inserted.</returns>
        public int InsertTVShow(TVShow tvShow)
        {
            // Validate the paramater
            if (tvShow == null)
            {
                throw new ArgumentNullException("The tvShow argument cannot be null.");
            }
            const string SQL = """
                                INSERT INTO tvshow (Title, ReleaseDate, Synopsis, ImageLink)
                                VALUES (@Title, @ReleaseDate, @Synopsis, @ImageLink);
                                """;
            const string PK_SQL = """
                                   SELECT TVShowID FROM tvshow WHERE rowid = last_insert_rowid();
                                   """;
            int id = -1;
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            using (SQLiteCommand pkCmd = new SQLiteCommand(PK_SQL, _connection))
            {
                // Form the SQL statement using data from the user
                cmd.Parameters.AddWithValue("@Title", tvShow.Title);
                cmd.Parameters.AddWithValue("@ReleaseDate", tvShow.ReleaseDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Synopsis", tvShow.Sysnopsis);
                cmd.Parameters.AddWithValue("@ImageLink", tvShow.ImageLink);
                // Execute the SQL query using data from the user
                cmd.ExecuteNonQuery();
                // Get the PK
                id = Convert.ToInt32(pkCmd.ExecuteScalar());
            }
            return id;
        }

        /// <summary>
        /// Insert an episode into the episode table.
        /// </summary>
        /// <param name="episode">The episode to insert.</param>
        /// <exception cref="ArgumentNullException">Exception thrown when the episode argument is null.</exception>
        public void InsertEpisode(Episode episode)
        {
            // Validate the parameter
            if (episode == null)
            {
                throw new ArgumentNullException("The episode argument cannot be null.");
            }
            const string SQL = """
                                INSERT INTO episode (Title, ReleaseDate, Synopsis, Duration, SeasonNumber, EpisodeNumber, ImageLink, TVShowID)
                                VALUES (@Title, @ReleaseDate, @Synopsis, @Duration, @SeasonNumber, @EpisodeNumber, @ImageLink, @TVShowID);
                                """;
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                // Form the SQL statement using data from the user
                cmd.Parameters.AddWithValue("@Title", episode.Title);
                cmd.Parameters.AddWithValue("@ReleaseDate", episode.ReleaseDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Synopsis", episode.Sysnopsis);
                cmd.Parameters.AddWithValue("@Duration", episode.Duration);
                cmd.Parameters.AddWithValue("@SeasonNumber", episode.SeasonNumber);
                cmd.Parameters.AddWithValue("@EpisodeNumber", episode.EpisodeNumber);
                cmd.Parameters.AddWithValue("@ImageLink", episode.ImageLink);
                cmd.Parameters.AddWithValue("@Synopsis", episode.TVShowId);
                // Execute the SQL query using data from the user
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Insert a review for a director.
        /// </summary>
        /// <param name="review">The review of the director.</param>
        /// <param name="directorId">The director being reviewed</param>
        /// <exception cref="ArgumentNullException">Exception thrown when the review argument is null.</exception>
        public void InsertReview(Review review, int directorId)
        {
            // Validate the parameter
            if (review == null)
            {
                throw new ArgumentNullException("The review argument cannot be null.");
            }
            const string REVIEW_INS = """
                                       INSERT INTO review (Comment, Rating, UserID)
                                       VALUES (@Comment, @Rating, @UserID);
                                       """;
            const string LAST_REVIEW_ID = """
                                           SELECT ReviewID FROM review WHERE rowid = last_insert_rowid();
                                           """;
            const string DIR_REVIEW_INS = """
                                           INSERT INTO directorreview (DirectorID, ReviewID)
                                           VALUES (@DirectorID, @ReviewID);
                                           """;
            using (SQLiteCommand reviewInsCmd = new SQLiteCommand(REVIEW_INS, _connection))
            using (SQLiteCommand lastIdCmd = new SQLiteCommand(LAST_REVIEW_ID, _connection))
            using (SQLiteCommand dirReviewInsCmd = new SQLiteCommand(DIR_REVIEW_INS, _connection))
            {
                // Form the review insert SQL statement
                reviewInsCmd.Parameters.AddWithValue("@Comment", review.Comment);
                reviewInsCmd.Parameters.AddWithValue("@Rating", review.Rating);
                reviewInsCmd.Parameters.AddWithValue("@UserID", review.Author.Id);
                // Execute the insert
                reviewInsCmd.ExecuteNonQuery();
                
                // Get the ID of the inserted row
                int reviewId = (int) lastIdCmd.ExecuteScalar();

                // Form the director review insert SQL statement
                dirReviewInsCmd.Parameters.AddWithValue("@DirectorID", directorId);
                dirReviewInsCmd.Parameters.AddWithValue("@ReviewID", reviewId);
                // Execute the insert
                dirReviewInsCmd.ExecuteNonQuery();
            }

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
                                    ImageLink TEXT NOT NULL,
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
                                    ImageLink TEXT NOT NULL,
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
