using Microsoft.VisualBasic.Devices;
using MovieDatabase.Exceptions;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.DirectoryServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
        /// Get a user based on the username and password.
        /// </summary>
        /// <param name="userName">The username of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>The user with the specified credentials, or null if the user does not exist.</returns>
        /// <exception cref="ArgumentNullException">Exception thrown when the userName or password arguments are null.</exception>
        public User? GetUserByCredentials(string userName, string password)
        {
            // Validate the parameters
            if (userName == null || password == null)
            {
                throw new ArgumentNullException("The userName or password arguments cannot be null.");
            }
            const string SQL = """
                                SELECT * FROM user u LEFT JOIN payment p ON p.UserID = u.UserID
                                WHERE u.UserName = @UserName AND u.Password = @Password;
                                """;
            User? user = null;
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                cmd.Parameters.AddWithValue("@UserName", userName);
                cmd.Parameters.AddWithValue("@Password", password);

                // Execute the SQL and read the next result
                SQLiteDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    return null;
                }

                // If the PaymentID field is present, the user has a premium membership
                User.Memberships membership = User.Memberships.REGULAR;
                if (reader["PaymentID"] == DBNull.Value)
                {
                    membership = User.Memberships.PREMIUM;
                }

                // Parse the date of birth
                DateTime dob = DateTime.Parse((string)reader["DateOfBirth"]);
                // Create the user object
                user = new User((string)reader["UserName"], (string)reader["Password"],
                    (string)reader["FirstName"], (string)reader["LastName"], dob, membership);
                // Set the user ID
                user.Id = Convert.ToInt32(reader["UserID"]);
                // Set the watchlist and reviews
                user.WatchList = GetUserWatchList(user.Id);
                user.WrittenReviews = GetUserReviews(user.Id);
            }
            return user;
        }

        /// <summary>
        /// Fetch all reviews for a given user.
        /// </summary>
        /// <param name="userId">The user ID of the user whose reviews are to be fetched.</param>
        /// <returns>A list of all of the reviews of the user.</returns>
        private List<Review> GetUserReviews(int userId)
        {
            const string SQL = """
                                SELECT * FROM review WHERE UserID = @UserID;
                                """;
            List<Review> reviews = new List<Review>();
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                // Form the SQL statement and execute the query
                cmd.Parameters.AddWithValue("@UserID", userId);
                SQLiteDataReader reviewReader = cmd.ExecuteReader();

                // Loop through the results and fetch all reviews
                while (reviewReader.Read())
                {
                    Review review = new Review(Convert.ToInt32(reviewReader["UserID"]), (string)reviewReader["Comment"], (double)reviewReader["Rating"]);
                    review.ReviewId = Convert.ToInt32(reviewReader["ReviewID"]);
                    reviews.Add(review);
                }
            }
            return reviews;
        }

        /// <summary>
        /// Get the watch list of the user.
        /// </summary>
        /// <param name="userId">The user ID of the user.</param>
        /// <returns>The watch list of the user.</returns>
        private List<Media> GetUserWatchList(int userId)
        {
            const string MOVIE_SQL = """
                                SELECT m.* FROM movie m JOIN watchlistmovie wl on m.MovieID = wl.MovieID WHERE wl.UserID = @UserID;
                                """;
            const string TVSHOW_SQL = """
                                       SELECT t.* FROM tvshow t JOIN watchlisttvshow wl on t.TVShowID = wl.TVShowID WHERE wl.UserID = @UserID;
                                       """;
            List<Media> watchList = new List<Media>();
            using (SQLiteCommand movieCmd = new SQLiteCommand(MOVIE_SQL, _connection))
            using (SQLiteCommand tvShowCmd = new SQLiteCommand(TVSHOW_SQL, _connection))
            {
                // Form the SQL and execute the queries
                movieCmd.Parameters.AddWithValue("@UserID", userId);
                tvShowCmd.Parameters.AddWithValue("@UserID", userId);
                SQLiteDataReader movieReader = movieCmd.ExecuteReader();
                SQLiteDataReader tvShowReader = tvShowCmd.ExecuteReader();

                // Add Movies to the watchlist
                while (movieReader.Read())
                {
                    Movie movie = new Movie((string)movieReader["Title"], DateTime.Parse((string)movieReader["ReleaseDate"]),
                        (string)movieReader["Synopsis"], Convert.ToInt32(movieReader["Duration"]), (string)movieReader["ImageLink"]);
                    // Set the movie id
                    movie.MediaId = Convert.ToInt32(movieReader["MovieID"]);
                    // Set the movie reviews, directors, actors, and genres
                    movie.Reviews = GetMovieReviews(movie.MediaId);
                    movie.Directors = GetMovieDirectors(movie.MediaId);
                    movie.Actors = GetMovieActors(movie.MediaId);
                    movie.Genres = GetMovieGenres(movie.MediaId);
                    watchList.Add(movie);
                }

                // Add TV Shows to the watchlist
                while (tvShowReader.Read())
                {
                    TVShow tvShow = new TVShow((string)tvShowReader["Title"], DateTime.Parse((string)tvShowReader["ReleaseDate"]),
                        (string)tvShowReader["Synopsis"], (string)tvShowReader["ImageLink"]);
                    // Set the tv show id
                    tvShow.MediaId = Convert.ToInt32(tvShowReader["TVShowID"]);
                    // Set the tv show revies, directors, actors, genres, and episodes
                    tvShow.Episodes = GetTVShowEpisodes(tvShow.MediaId);
                    tvShow.Directors = GetTVShowDirectors(tvShow.MediaId);
                    tvShow.Actors = GetTVShowActors(tvShow.MediaId);
                    tvShow.Reviews = GetTVShowReviews(tvShow.MediaId);
                    tvShow.Genres = GetTVShowGenres(tvShow.MediaId);
                    watchList.Add(tvShow);
                }

            }
            return watchList;
        }

        /// <summary>
        /// Fetch all reviews for a given movie.
        /// </summary>
        /// <param name="movieId">The movieId of the movie whose reviews are to be fetched.</param>
        /// <returns>A list of all of the reviews of the movie.</returns>
        private List<Review> GetMovieReviews(int movieId)
        {
            const string SQL = """
                                SELECT r.* FROM review r JOIN moviereview mr on r.ReviewID = mr.ReviewID WHERE mr.MovieID = @MovieID;
                                """;
            List<Review> reviews = new List<Review>();
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                // Form the SQL statement and execute the query
                cmd.Parameters.AddWithValue("@MovieID", movieId);
                SQLiteDataReader reviewReader = cmd.ExecuteReader();

                // Loop through the results and fetch all reviews
                while (reviewReader.Read())
                {
                    Review review = new Review(Convert.ToInt32(reviewReader["UserID"]), (string)reviewReader["Comment"], (double)reviewReader["Rating"]);
                    review.ReviewId = Convert.ToInt32(reviewReader["ReviewID"]);
                    reviews.Add(review);
                }
            }
            return reviews;
        }

        /// <summary>
        /// Get the genres of a movie.
        /// </summary>
        /// <param name="movieId">The movie ID of the movie.</param>
        /// <returns>The list of genres of a movie.</returns>
        private List<Media.Genre> GetMovieGenres(int movieId)
        {
            const string SQL = """
                                SELECT g.GenreName FROM genre g JOIN moviegenre mg ON g.GenreID = mg.GenreID WHERE mg.MovieID = @MovieID;
                                """;
            List<Media.Genre> genres = new List<Media.Genre>();
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                // Form the SQL statement and execute the query
                cmd.Parameters.AddWithValue("@MovieID", movieId);
                SQLiteDataReader genreReader = cmd.ExecuteReader();

                // Loop through the results and fetch all reviews
                while (genreReader.Read())
                {
                    // Create the Genre and add it to the genres list
                    Media.Genre genre = (Media.Genre)Enum.Parse(typeof(Media.Genre), (string)genreReader["GenreName"]);
                    genres.Add(genre);
                }
            }
            return genres;
        }

        /// <summary>
        /// Get the actors starring a movie.
        /// </summary>
        /// <param name="movieId">The movie ID of the movie.</param>
        /// <returns>A list of all of the actors starring the specified movie.</returns>
        private List<Actor> GetMovieActors(int movieId)
        {
            const string SQL = """
                                SELECT a.* FROM actor a JOIN movieactor ma ON a.ActorID = ma.ActorID WHERE ma.MovieID = @MovieID;
                                """;
            List<Actor> actors = new List<Actor>();
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                // Form the SQL statement and execute the query
                cmd.Parameters.AddWithValue("@MovieID", movieId);
                SQLiteDataReader actorReader = cmd.ExecuteReader();

                // Loop through the results and fetch all actors
                while (actorReader.Read())
                {
                    // Create an actor
                    Actor actor = new Actor((string)actorReader["FirstName"], (string)actorReader["LastName"], (string)actorReader["ImageLink"]);
                    // Set the actor id
                    actor.Id = Convert.ToInt32(actorReader["ActorID"]);
                    // Set the lists of starred media
                    Dictionary<string, List<int>> starredIds = GetActorStarred(actor.Id);
                    actor.StarredMovies = starredIds["MovieIds"];
                    actor.StarredTVShows = starredIds["TVShowIds"];
                    actor.StarredEpisodes = starredIds["EpisodeIds"];
                }
            }
            return actors;
        }

        /// <summary>
        /// Get the list of directors of a movie.
        /// </summary>
        /// <param name="movieId">The movie Id of the movie.</param>
        /// <returns>The list of directors directing the movie specified by movieId.</returns>
        private List<Director> GetMovieDirectors(int movieId)
        {
            const string SQL = """
                                SELECT d.* FROM director d JOIN moviedirector md ON d.DirectorID = md.DirectorID WHERE md.MovieID = @MovieID;
                                """;
            List<Director> directors = new List<Director>();
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                // Form the SQL statement and execute the query
                cmd.Parameters.AddWithValue("@MovieID", movieId);
                SQLiteDataReader directorReader = cmd.ExecuteReader();

                // Loop through the results and fetch all directors
                while (directorReader.Read())
                {
                    // Create a director
                    Director director = new Director((string)directorReader["FirstName"], (string)directorReader["LastName"], (string)directorReader["ImageLink"]);
                    // Set the director id
                    director.Id = Convert.ToInt32(directorReader["DirectorID"]);
                    // Set the lists of directed media
                    Dictionary<string, List<int>> directedIds = GetDirectorDirected(director.Id);
                    director.DirectedMovies = directedIds["MovieIds"];
                    director.DirectedTVShows = directedIds["TVShowIds"];
                    director.DirectedEpisodes = directedIds["EpisodeIds"];
                }
            }
            return directors;
        }

        /// <summary>
        /// Fetch all reviews for a given episode.
        /// </summary>
        /// <param name="episodeId">The episode ID of the episode whose reviews are to be fetched.</param>
        /// <returns>A list of all of the reviews of the episode.</returns>
        private List<Review> GetEpisodeReviews(int episodeId)
        {
            const string SQL = """
                                SELECT r.* FROM review r JOIN episodereview er on r.ReviewID = r.ReviewID WHERE er.EpisodeID = @EpisodeID;
                                """;
            List<Review> reviews = new List<Review>();
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                // Form the SQL statement and execute the query
                cmd.Parameters.AddWithValue("@EpisodeID", episodeId);
                SQLiteDataReader reviewReader = cmd.ExecuteReader();

                // Loop through the results and fetch all reviews
                while (reviewReader.Read())
                {
                    // Create a review and all it to the reviews list
                    Review review = new Review(Convert.ToInt32(reviewReader["UserID"]), (string)reviewReader["Comment"], (double)reviewReader["Rating"]);
                    review.ReviewId = Convert.ToInt32(reviewReader["ReviewID"]);
                    reviews.Add(review);
                }
            }
            return reviews;
        }

        /// <summary>
        /// Get the genres of an episode.
        /// </summary>
        /// <param name="episodeId">The episode ID of the episode.</param>
        /// <returns>The list of genres of an episode.</returns>
        private List<Media.Genre> GetEpisodeGenres(int episodeId)
        {
            const string SQL = """
                                SELECT g.GenreName FROM genre g JOIN episodegenre eg ON g.GenreID = eg.GenreID WHERE eg.EpisodeID = @EpisodeID;
                                """;
            List<Media.Genre> genres = new List<Media.Genre>();
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                // Form the SQL statement and execute the query
                cmd.Parameters.AddWithValue("@EpisodeID", episodeId);
                SQLiteDataReader genreReader = cmd.ExecuteReader();

                // Loop through the results and fetch all genres
                while (genreReader.Read())
                {
                    // Create the Genre and add it to the genres list
                    Media.Genre genre = (Media.Genre)Enum.Parse(typeof(Media.Genre), (string)genreReader["GenreName"]);
                    genres.Add(genre);
                }
            }
            return genres;
        }

        /// <summary>
        /// Get the actors starring an episode.
        /// </summary>
        /// <param name="episodeId">The episode ID of the episode.</param>
        /// <returns>A list of all of the actors starring the specified episode.</returns>
        private List<Actor> GetEpisodeActors(int episodeId)
        {
            const string SQL = """
                                SELECT a.* FROM actor a JOIN episodeactor ea ON a.ActorID = ea.ActorID WHERE ea.EpisodeID = @EpisodeID;
                                """;
            List<Actor> actors = new List<Actor>();
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                // Form the SQL statement and execute the query
                cmd.Parameters.AddWithValue("@EpisodeID", episodeId);
                SQLiteDataReader actorReader = cmd.ExecuteReader();

                // Loop through the results and fetch all actors
                while (actorReader.Read())
                {
                    // Create an actor
                    Actor actor = new Actor((string)actorReader["FirstName"], (string)actorReader["LastName"], (string)actorReader["ImageLink"]);
                    // Set the actor id
                    actor.Id = Convert.ToInt32(actorReader["ActorID"]);
                    // Set the lists of starred media
                    Dictionary<string, List<int>> starredIds = GetActorStarred(actor.Id);
                    actor.StarredMovies = starredIds["MovieIds"];
                    actor.StarredTVShows = starredIds["TVShowIds"];
                    actor.StarredEpisodes = starredIds["EpisodeIds"];
                }
            }
            return actors;
        }

        /// <summary>
        /// Get the list of directors of an episode.
        /// </summary>
        /// <param name="episodeId">The episode Id of the episode.</param>
        /// <returns>The list of directors directing the episode specified by episodeId.</returns>
        private List<Director> GetEpisodeDirectors(int episodeId)
        {
            const string SQL = """
                                SELECT d.* FROM director d JOIN episodedirector ed ON d.DirectorID = ed.DirectorID WHERE ed.EpisodeID = @EpisodeID;
                                """;
            List<Director> directors = new List<Director>();
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                // Form the SQL statement and execute the query
                cmd.Parameters.AddWithValue("@EpisodeID", episodeId);
                SQLiteDataReader directorReader = cmd.ExecuteReader();

                // Loop through the results and fetch all directors
                while (directorReader.Read())
                {
                    // Create a director
                    Director director = new Director((string)directorReader["FirstName"], (string)directorReader["LastName"], (string)directorReader["ImageLink"]);
                    // Set the director id
                    director.Id = Convert.ToInt32(directorReader["DirectorID"]);
                    // Set the lists of directed media
                    Dictionary<string, List<int>> directedIds = GetDirectorDirected(director.Id);
                    director.DirectedMovies = directedIds["MovieIds"];
                    director.DirectedTVShows = directedIds["TVShowIds"];
                    director.DirectedEpisodes = directedIds["EpisodeIds"];
                }
            }
            return directors;
        }

        /// <summary>
        /// Fetch all reviews for a given tv show.
        /// </summary>
        /// <param name="tvShowId">The tv show ID of the tv show whose reviews are to be fetched.</param>
        /// <returns>A list of all of the reviews of the tv show.</returns>
        private List<Review> GetTVShowReviews(int tvShowId)
        {
            const string SQL = """
                                SELECT r.* FROM review r JOIN tvshowreview tr on r.ReviewID = r.ReviewID WHERE tr.TVShowID = @TVShowID;
                                """;
            List<Review> reviews = new List<Review>();
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                // Form the SQL statement and execute the query
                cmd.Parameters.AddWithValue("@TVShowID", tvShowId);
                SQLiteDataReader reviewReader = cmd.ExecuteReader();

                // Loop through the results and fetch all reviews
                while (reviewReader.Read())
                {
                    Review review = new Review(Convert.ToInt32(reviewReader["UserID"]), (string)reviewReader["Comment"], (double)reviewReader["Rating"]);
                    review.ReviewId = Convert.ToInt32(reviewReader["ReviewID"]);
                    reviews.Add(review);
                }
            }
            return reviews;
        }

        /// <summary>
        /// Get the genres of a tv show.
        /// </summary>
        /// <param name="tvShowId">The tv show ID of the tv show.</param>
        /// <returns>The list of genres of a tv show.</returns>
        private List<Media.Genre> GetTVShowGenres(int tvShowId)
        {
            const string SQL = """
                                SELECT g.GenreName FROM genre g JOIN tvshowgenre tg ON g.GenreID = tg.GenreID WHERE tg.TVShowID = @TVShowID;
                                """;
            List<Media.Genre> genres = new List<Media.Genre>();
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                // Form the SQL statement and execute the query
                cmd.Parameters.AddWithValue("@TVShowID", tvShowId);
                SQLiteDataReader genreReader = cmd.ExecuteReader();

                // Loop through the results and fetch all genres
                while (genreReader.Read())
                {
                    // Create the Genre and add it to the genres list
                    Media.Genre genre = (Media.Genre)Enum.Parse(typeof(Media.Genre), (string)genreReader["GenreName"]);
                    genres.Add(genre);
                }
            }
            return genres;
        }

        /// <summary>
        /// Get the actors starring a tv show.
        /// </summary>
        /// <param name="tvShowId">The tv show ID of the tv show.</param>
        /// <returns>A list of all of the actors starring the specified tv show.</returns>
        private List<Actor> GetTVShowActors(int tvShowId)
        {
            const string SQL = """
                                SELECT a.* FROM actor a JOIN tvshowactor ta ON a.ActorID = ta.ActorID WHERE ta.TVShowID = @tvShowId;
                                """;
            List<Actor> actors = new List<Actor>();
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                // Form the SQL statement and execute the query
                cmd.Parameters.AddWithValue("@TVShowID", tvShowId);
                SQLiteDataReader actorReader = cmd.ExecuteReader();

                // Loop through the results and fetch all actors
                while (actorReader.Read())
                {
                    // Create an actor
                    Actor actor = new Actor((string)actorReader["FirstName"], (string)actorReader["LastName"], (string)actorReader["ImageLink"]);
                    // Set the actor id
                    actor.Id = Convert.ToInt32(actorReader["ActorID"]);
                    // Set the lists of starred media
                    Dictionary<string, List<int>> starredIds = GetActorStarred(actor.Id);
                    actor.StarredMovies = starredIds["MovieIds"];
                    actor.StarredTVShows = starredIds["TVShowIds"];
                    actor.StarredEpisodes = starredIds["EpisodeIds"];
                }
            }
            return actors;
        }

        /// <summary>
        /// Get the list of directors of a tv show.
        /// </summary>
        /// <param name="tvShowId">The tv show Id of the tv show.</param>
        /// <returns>The list of directors directing the tv show specified by tvShowId.</returns>
        private List<Director> GetTVShowDirectors(int tvShowId)
        {
            const string SQL = """
                                SELECT d.* FROM director d JOIN tvshowdirector td ON d.DirectorID = td.DirectorID WHERE td.TVShowID = @TVShowID;
                                """;
            List<Director> directors = new List<Director>();
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                // Form the SQL statement and execute the query
                cmd.Parameters.AddWithValue("@TVShowID", tvShowId);
                SQLiteDataReader directorReader = cmd.ExecuteReader();

                // Loop through the results and fetch all directors
                while (directorReader.Read())
                {
                    // Create a director
                    Director director = new Director((string)directorReader["FirstName"], (string)directorReader["LastName"], (string)directorReader["ImageLink"]);
                    // Set the director id
                    director.Id = Convert.ToInt32(directorReader["DirectorID"]);
                    // Set the lists of directed media
                    Dictionary<string, List<int>> directedIds = GetDirectorDirected(director.Id);
                    director.DirectedMovies = directedIds["MovieIds"];
                    director.DirectedTVShows = directedIds["TVShowIds"];
                    director.DirectedEpisodes = directedIds["EpisodeIds"];
                }
            }
            return directors;
        }

        /// <summary>
        /// Get the list of episodes of a tv show.
        /// </summary>
        /// <param name="tvShowId">The tv show ID of the tv show.</param>
        /// <returns>The list of episodes of a tv show.</returns>
        private List<Episode> GetTVShowEpisodes(int tvShowId)
        {
            const string SQL = """
                                SELECT * FROM episode WHERE TVShowID = @TVShowID;
                                """;
            List<Episode> episodes = new List<Episode>();
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                // Form the SQL statement and execute the query
                cmd.Parameters.AddWithValue("@TVShowID", tvShowId);
                SQLiteDataReader episodeReader = cmd.ExecuteReader();

                // Loop through the results and fetch all episodes
                while (episodeReader.Read())
                {
                    // Create an episode
                    Episode episode = new Episode((string)episodeReader["Title"], DateTime.Parse((string)episodeReader["ReleaseDate"]),
                        (string)episodeReader["Synopsis"], (string)episodeReader["ImageLink"], Convert.ToInt32(episodeReader["Duration"]),
                        Convert.ToInt32(episodeReader["SeasonNumber"]), Convert.ToInt32(episodeReader["EpisodeNumber"]));
                    // Set the episode
                    episode.MediaId = Convert.ToInt32(episodeReader["EpisodeID"]);
                    // Set the movie reviews, directors, actors, genres, and episodes
                    episode.Reviews = GetEpisodeReviews(episode.MediaId);
                    episode.Directors = GetEpisodeDirectors(episode.MediaId);
                    episode.Actors = GetEpisodeActors(episode.MediaId);
                    episode.Genres = GetEpisodeGenres(episode.MediaId);
                    // Add the episodes
                    episodes.Add(episode);
                }
            }
            return episodes;
        }

        /// <summary>
        /// Get the list of ids of the movies, tv shows, and episodes featuring 
        /// an actor.
        /// </summary>
        /// <param name="actorId">The actor ID of the actor.</param>
        /// <returns>A dictionnary containing the list of ids of the movies, tv shows, and episodes.</returns>
        private Dictionary<string, List<int>> GetActorStarred(int actorId)
        {
            const string MOVIE_SQL = """
                                SELECT MovieID FROM movieactor WHERE ActorID = @ActorID;
                                """;
            const string TVSHOW_SQL = """
                                SELECT TVShowID FROM tvshowactor WHERE ActorID = @ActorID;
                                """;
            const string EPISODE_SQL = """
                                SELECT EpisodeID FROM episodeactor WHERE ActorID = @ActorID;
                                """;

            Dictionary<String, List<int>> starredIds = new Dictionary<String, List<int>>();
            starredIds["MovieIds"] = new List<int>();
            starredIds["TVShowIds"] = new List<int>();
            starredIds["EpisodeIds"] = new List<int>();

            using (SQLiteCommand movieCmd = new SQLiteCommand(MOVIE_SQL, _connection))
            using (SQLiteCommand tvShowCmd = new SQLiteCommand(TVSHOW_SQL, _connection))
            using (SQLiteCommand episodeCmd = new SQLiteCommand(EPISODE_SQL, _connection))
            {
                // Form the SQL statements and execute the queries
                movieCmd.Parameters.AddWithValue("@ActorID", actorId);
                tvShowCmd.Parameters.AddWithValue("@ActorID", actorId);
                episodeCmd.Parameters.AddWithValue("@ActorID", actorId);
                SQLiteDataReader movieReader = movieCmd.ExecuteReader();
                SQLiteDataReader tvShowReader = tvShowCmd.ExecuteReader();
                SQLiteDataReader episodeReader = episodeCmd.ExecuteReader();

                // Loop through the movie results
                while (movieReader.Read())
                {
                    starredIds["MovieIds"].Add(Convert.ToInt32(movieReader["MovieID"]));
                }

                // Loop through the tv show results
                while (tvShowReader.Read())
                {
                    starredIds["TVShowIds"].Add(Convert.ToInt32(tvShowReader["TVShowID"]));
                }

                // Loop through the episode results
                while (episodeReader.Read())
                {
                    starredIds["EpisodeIds"].Add(Convert.ToInt32(episodeReader["EpisodeID"]));
                }
            }
            return starredIds;
        }

        /// <summary>
        /// Get the list of ids of the movies, tv shows, and episodes directed by 
        /// a director.
        /// </summary>
        /// <param name="directorId">The director ID of the director.</param>
        /// <returns>A dictionnary containing the list of ids of movies, tv shows, and episodes.</returns>
        private Dictionary<string, List<int>> GetDirectorDirected(int directorId)
        {
            const string MOVIE_SQL = """
                                SELECT MovieID FROM moviedirector WHERE DirectorID = @DirectorID;
                                """;
            const string TVSHOW_SQL = """
                                SELECT TVShowID FROM tvshowdirector WHERE DirectorID = @DirectorID;
                                """;
            const string EPISODE_SQL = """
                                SELECT EpisodeID FROM episodedirector WHERE DirectorID = @DirectorID;
                                """;

            Dictionary<String, List<int>> directedIds = new Dictionary<String, List<int>>();
            directedIds["MovieIds"] = new List<int>();
            directedIds["TVShowIds"] = new List<int>();
            directedIds["EpisodeIds"] = new List<int>();

            using (SQLiteCommand movieCmd = new SQLiteCommand(MOVIE_SQL, _connection))
            using (SQLiteCommand tvShowCmd = new SQLiteCommand(TVSHOW_SQL, _connection))
            using (SQLiteCommand episodeCmd = new SQLiteCommand(EPISODE_SQL, _connection))
            {
                // Form the SQL statements and execute the queries
                movieCmd.Parameters.AddWithValue("@DirectorID", directorId);
                tvShowCmd.Parameters.AddWithValue("@DirectorID", directorId);
                episodeCmd.Parameters.AddWithValue("@DirectorID", directorId);
                SQLiteDataReader movieReader = movieCmd.ExecuteReader();
                SQLiteDataReader tvShowReader = tvShowCmd.ExecuteReader();
                SQLiteDataReader episodeReader = episodeCmd.ExecuteReader();

                // Loop through the movie results
                while (movieReader.Read())
                {
                    directedIds["MovieIds"].Add(Convert.ToInt32(movieReader["MovieID"]));
                }

                // Loop through the tv show results
                while (tvShowReader.Read())
                {
                    directedIds["TVShowIds"].Add(Convert.ToInt32(tvShowReader["TVShowID"]));
                }

                // Loop through the episode results
                while (episodeReader.Read())
                {
                    directedIds["EpisodeIds"].Add(Convert.ToInt32(episodeReader["EpisodeID"]));
                }
            }
            return directedIds;
        }

        /// <summary>
        /// Get all of the movies stored in the database.
        /// </summary>
        /// <returns>A list of all of the movies.</returns>
        public List<Movie> GetAllMovies()
        {
            const string SQL = """
                                SELECT * FROM movie;
                                """;
            List<Movie> movies = new List<Movie>();
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                SQLiteDataReader movieReader = cmd.ExecuteReader();
                while (movieReader.Read())
                {
                    // Create a movie
                    Movie movie = new Movie((string)movieReader["Title"], DateTime.Parse((string)movieReader["ReleaseDate"]),
                        (string)movieReader["Synopsis"], Convert.ToInt32(movieReader["Duration"]), (string)movieReader["ImageLink"]);
                    // Set the movie id
                    movie.MediaId = Convert.ToInt32(movieReader["MovieID"]);
                    // Set the movie reviews, directors, actors, and genres
                    movie.Reviews = GetMovieReviews(movie.MediaId);
                    movie.Directors = GetMovieDirectors(movie.MediaId);
                    movie.Actors = GetMovieActors(movie.MediaId);
                    movie.Genres = GetMovieGenres(movie.MediaId);
                    movies.Add(movie);
                }
            }
            return movies;
        }

        /// <summary>
        /// Get all of the tv shows stored in the database.
        /// </summary>
        /// <returns>The list of all tv shows in the database.</returns>
        public List<TVShow> GetAllTVShows()
        {
            const string SQL = """
                                SELECT * FROM tvshow;
                                """;
            List<TVShow> tvShows = new List<TVShow>();
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                SQLiteDataReader tvShowReader = cmd.ExecuteReader();
                while (tvShowReader.Read())
                {
                    TVShow tvShow = new TVShow((string)tvShowReader["Title"], DateTime.Parse((string)tvShowReader["ReleaseDate"]),
                        (string)tvShowReader["Synopsis"], (string)tvShowReader["ImageLink"]);
                    // Set the tv show id
                    tvShow.MediaId = Convert.ToInt32(tvShowReader["TVShowID"]);
                    // Set the tv show revies, directors, actors, genres, and episodes
                    tvShow.Episodes = GetTVShowEpisodes(tvShow.MediaId);
                    tvShow.Directors = GetTVShowDirectors(tvShow.MediaId);
                    tvShow.Actors = GetTVShowActors(tvShow.MediaId);
                    tvShow.Reviews = GetTVShowReviews(tvShow.MediaId);
                    tvShow.Genres = GetTVShowGenres(tvShow.MediaId);
                    tvShows.Add(tvShow);
                }
            }
            return tvShows;
        }

        /// <summary>
        /// Get all of the media stored in the database.
        /// </summary>
        /// <returns>A list of all of the media stored in the database.</returns>
        public List<Media> GetAllMedia()
        {
            List<Media> list = new List<Media>();
            // Add the movies
            list.AddRange(GetAllMovies());
            // Add the tv shows
            list.AddRange(GetAllTVShows());
            return list;
        }

        /// <summary>
        /// Get all of the movies that have the genre specified.
        /// </summary>
        /// <param name="genre">The genre to filter by.</param>
        /// <returns>A list of all of the movies of that genre.</returns>
        public List<Movie> GetMoviesByGenre(Media.Genre genre)
        {
            const string SQL = """
                                SELECT m.* FROM movie m 
                                JOIN moviegenre mg ON m.MovieID = mg.MovieID
                                JOIN genre g ON g.GenreID = mg.GenreID
                                WHERE g.GenreName = @GenreName;
                                """;
            List<Movie> movies = new List<Movie>();
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                // Form the SQL and execute the query
                cmd.Parameters.AddWithValue("@GenreName", genre.ToString().ToUpper());
                SQLiteDataReader movieReader = cmd.ExecuteReader();

                // Get all of the movie results
                while (movieReader.Read())
                {
                    // Create a movie
                    Movie movie = new Movie((string)movieReader["Title"], DateTime.Parse((string)movieReader["ReleaseDate"]),
                        (string)movieReader["Synopsis"], Convert.ToInt32(movieReader["Duration"]), (string)movieReader["ImageLink"]);
                    // Set the movie id
                    movie.MediaId = Convert.ToInt32(movieReader["MovieID"]);
                    // Set the movie reviews, directors, actors, and genres
                    movie.Reviews = GetMovieReviews(movie.MediaId);
                    movie.Directors = GetMovieDirectors(movie.MediaId);
                    movie.Actors = GetMovieActors(movie.MediaId);
                    movie.Genres = GetMovieGenres(movie.MediaId);
                    movies.Add(movie);
                }
            }
            return movies;
        }

        /// <summary>
        /// Get all of the tv shows that have the genre specified.
        /// </summary>
        /// <param name="genre">The genre to filter by.</param>
        /// <returns>A list of all of the tv shows of that genre.</returns>
        public List<TVShow> GetTVShowsByGenre(Media.Genre genre)
        {
            const string SQL = """
                                SELECT t.* FROM tvshow t 
                                JOIN tvshowgenre tg ON t.MovieID = tg.MovieID
                                JOIN genre g ON g.GenreID = tg.GenreID
                                WHERE g.GenreName = @GenreName;
                                """;
            List<TVShow> tvShows = new List<TVShow>();
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                // Form the SQL and execute the query
                cmd.Parameters.AddWithValue("GenreName", genre.ToString().ToUpper());
                SQLiteDataReader tvShowReader = cmd.ExecuteReader();

                // Get all of the tv show results
                while (tvShowReader.Read())
                {
                    TVShow tvShow = new TVShow((string)tvShowReader["Title"], DateTime.Parse((string)tvShowReader["ReleaseDate"]),
                        (string)tvShowReader["Synopsis"], (string)tvShowReader["ImageLink"]);
                    // Set the tv show id
                    tvShow.MediaId = Convert.ToInt32(tvShowReader["TVShowID"]);
                    // Set the tv show revies, directors, actors, genres, and episodes
                    tvShow.Episodes = GetTVShowEpisodes(tvShow.MediaId);
                    tvShow.Directors = GetTVShowDirectors(tvShow.MediaId);
                    tvShow.Actors = GetTVShowActors(tvShow.MediaId);
                    tvShow.Reviews = GetTVShowReviews(tvShow.MediaId);
                    tvShow.Genres = GetTVShowGenres(tvShow.MediaId);
                    tvShows.Add(tvShow);
                }
            }
            return tvShows;
        }

        /// <summary>
        /// Get all of the media that have the genre specified.
        /// </summary>
        /// <param name="genre">The genre to filter by.</param>
        /// <returns>A list of all of the media of that genre.</returns>
        public List<Media> GetMediaByGenre(Movie.Genre genre)
        {
            List<Media> media = new List<Media>();
            media.AddRange(GetMoviesByGenre(genre));
            media.AddRange(GetTVShowsByGenre(genre));
            return media;
        }

        /// <summary>
        /// Get a tv show by id.
        /// </summary>
        /// <param name="tvShowId">The ID of the tv show.</param>
        /// <returns>The TVShow with the specified ID.</returns>
        public TVShow? GetTVShowById(int tvShowId)
        {
            const string SQL = """
                                SELECT * FROM tvshow WHERE TVShowID = @TVShowID;
                                """;
            TVShow? tvShow = null;
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                cmd.Parameters.AddWithValue("@TVShowID", tvShowId);
                SQLiteDataReader tvShowReader = cmd.ExecuteReader();

                // If no result, return
                if (!tvShowReader.Read())
                {
                    return null;
                }

                // Create the tv show
                tvShow = new TVShow((string)tvShowReader["Title"], DateTime.Parse((string)tvShowReader["ReleaseDate"]),
                    (string)tvShowReader["Synopsis"], (string)tvShowReader["ImageLink"]);
                // Set the tv show id
                tvShow.MediaId = Convert.ToInt32(tvShowReader["TVShowID"]);
                // Set the tv show revies, directors, actors, genres, and episodes
                tvShow.Episodes = GetTVShowEpisodes(tvShow.MediaId);
                tvShow.Directors = GetTVShowDirectors(tvShow.MediaId);
                tvShow.Actors = GetTVShowActors(tvShow.MediaId);
                tvShow.Reviews = GetTVShowReviews(tvShow.MediaId);
                tvShow.Genres = GetTVShowGenres(tvShow.MediaId);
            }
            return tvShow;
        }

        /// <summary>
        /// Get an episode by id.
        /// </summary>
        /// <param name="episodeId">The ID of the episode.</param>
        /// <returns>The Episode with the specified ID.</returns>
        public Episode? GetEpisodeById(int episodeId)
        {
            const string SQL = """
                                SELECT * FROM episode WHERE EpisodeID = @EpisodeID;
                                """;
            Episode? episode = null;
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                cmd.Parameters.AddWithValue("@EpisodeID", episodeId);
                SQLiteDataReader episodeReader = cmd.ExecuteReader();

                // If no result, return
                if (!episodeReader.Read())
                {
                    return null;
                }

                // Create an episode
                episode = new Episode((string)episodeReader["Title"], DateTime.Parse((string)episodeReader["ReleaseDate"]),
                    (string)episodeReader["Synopsis"], (string)episodeReader["ImageLink"], Convert.ToInt32(episodeReader["Duration"]),
                    Convert.ToInt32(episodeReader["SeasonNumber"]), Convert.ToInt32(episodeReader["EpisodeNumber"]));
                // Set the episode
                episode.MediaId = Convert.ToInt32(episodeReader["EpisodeID"]);
                // Set the movie reviews, directors, actors, genres, and episodes
                episode.Reviews = GetEpisodeReviews(episode.MediaId);
                episode.Directors = GetEpisodeDirectors(episode.MediaId);
                episode.Actors = GetEpisodeActors(episode.MediaId);
                episode.Genres = GetEpisodeGenres(episode.MediaId);
            }
            return episode;
        }

        /// <summary>
        /// Get a movie by id.
        /// </summary>
        /// <param name="movieId">The ID of the movie.</param>
        /// <returns>The Movie with the specified ID.</returns>
        public Movie? GetMovieById(int movieId)
        {
            const string SQL = """
                                SELECT * FROM movie WHERE MovieID = @MovieID;
                                """;
            Movie? movie = null;
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                cmd.Parameters.AddWithValue("@MovieID", movieId);
                SQLiteDataReader movieReader = cmd.ExecuteReader();

                // If no result, return
                if (!movieReader.Read())
                {
                    return null;
                }

                // Create the movie
                movie = new Movie((string)movieReader["Title"], DateTime.Parse((string)movieReader["ReleaseDate"]),
                        (string)movieReader["Synopsis"], Convert.ToInt32(movieReader["Duration"]), (string)movieReader["ImageLink"]);
                // Set the movie id
                movie.MediaId = Convert.ToInt32(movieReader["MovieID"]);
                // Set the movie reviews, directors, actors, and genres
                movie.Reviews = GetMovieReviews(movie.MediaId);
                movie.Directors = GetMovieDirectors(movie.MediaId);
                movie.Actors = GetMovieActors(movie.MediaId);
                movie.Genres = GetMovieGenres(movie.MediaId);
            }
            return movie;
        }

        /// <summary>
        /// Get a user by id.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>The User with the specified ID.</returns>
        public User? GetUserById(int userId)
        {
            const string SQL = """
                                SELECT * FROM user u 
                                LEFT JOIN payment p ON p.UserID = u.UserID
                                WHERE u.UserID = @UserID;
                                """;
            User? user = null;
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                cmd.Parameters.AddWithValue("@UserName", userId);

                // Execute the SQL and read the next result
                SQLiteDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    return null;
                }

                // If the PaymentID field is present, the user has a premium membership
                User.Memberships membership = User.Memberships.REGULAR;
                if (reader["PaymentID"] == DBNull.Value)
                {
                    membership = User.Memberships.PREMIUM;
                }

                // Parse the date of birth
                DateTime dob = DateTime.Parse((string)reader["DateOfBirth"]);
                // Create the user object
                user = new User((string)reader["UserName"], (string)reader["Password"],
                    (string)reader["FirstName"], (string)reader["LastName"], dob, membership);
                // Set the user ID
                user.Id = Convert.ToInt32(reader["UserID"]);
                // Set the watchlist and reviews
                user.WatchList = GetUserWatchList(user.Id);
                user.WrittenReviews = GetUserReviews(user.Id);
            }
            return user;
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
                                INSERT INTO director (FirstName, LastName, ImageLink) VALUES (@FirstName, @LastName, @ImageLink);
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
                cmd.Parameters.AddWithValue("@ImageLink", director.ImageLink);
                // Execute the SQL
                cmd.ExecuteNonQuery();
                // Get the PK
                id = Convert.ToInt32(pkCmd.ExecuteScalar());
            }
            return id;
        }

        /// <summary>
        /// Insert a movie director entry into the moviedirector table.
        /// </summary>
        /// <param name="director">The director who directs the movie.</param>
        /// <param name="movie">The movie who is directed by the director.</param>
        /// <exception cref="ArgumentNullException">Exception thrown when the director or movie arguments are null.</exception>
        public void InsertDirectorMedia(Director director, Movie movie)
        {
            // Validate the parameters
            if (director == null || movie == null)
            {
                throw new ArgumentNullException("The director or movie arguments cannot be null.");
            }
            const string SQL = """
                                INSERT INTO moviedirector (DirectorID, MovieID) VALUES (@DirectorID, @MovieID);
                                """;
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                // Form the insert statement
                cmd.Parameters.AddWithValue("@DirectorID", director.Id);
                cmd.Parameters.AddWithValue("@MovieID", movie.MediaId);
                // Execute the insert
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Insert a tv show director entry into the tvshowdirector table.
        /// </summary>
        /// <param name="director">The director who directs the tv show.</param>
        /// <param name="tvShow">The tv show who is directed by the director.</param>
        /// <exception cref="ArgumentNullException">Exception thrown when the director or tvShow arguments are null.</exception>
        public void InsertDirectorMedia(Director director, TVShow tvShow)
        {
            // Validate the parameters
            if (director == null || tvShow == null)
            {
                throw new ArgumentNullException("The director or tvShow arguments cannot be null.");
            }
            const string SQL = """
                                INSERT INTO tvshowdirector (DirectorID, TVShowID) VALUES (@DirectorID, @TVShowID);
                                """;
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                // Form the insert statement
                cmd.Parameters.AddWithValue("@DirectorID", director.Id);
                cmd.Parameters.AddWithValue("@TVShowID", tvShow.MediaId);
                // Execute the insert
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Insert an episode director entry into the episodedirector table.
        /// </summary>
        /// <param name="director">The director who directs the episode.</param>
        /// <param name="episode">The episode who is directed by the director.</param>
        /// <exception cref="ArgumentNullException">Exception thrown when the director or episode arguments are null.</exception>
        public void InsertDirectorMedia(Director director, Episode episode)
        {
            // Validate the parameters
            if (director == null || episode == null)
            {
                throw new ArgumentNullException("The director or episode arguments cannot be null.");
            }
            const string SQL = """
                                INSERT INTO episodedirector (DirectorID, EpisodeID) VALUES (@DirectorID, @EpisodeID);
                                """;
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                // Form the insert statement
                cmd.Parameters.AddWithValue("@DirectorID", director.Id);
                cmd.Parameters.AddWithValue("@EpisodeID", episode.MediaId);
                // Execute the insert
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Insert an actor into the actor table.
        /// </summary>
        /// <param name="actor">The actor to insert.</param>
        /// <returns>The ActorID of the actor inserted.</returns>
        /// <exception cref="ArgumentNullException">Exception thrown when the actor argument is null.</exception>
        public int InsertActor(Actor actor)
        {
            // Validate the parameter
            if (actor == null)
            {
                throw new ArgumentNullException("The actor argument cannot be null.");
            }
            const string SQL = """
                                INSERT INTO actor (FirstName, LastName, ImageLink) VALUES (@FirstName, @LastName, @ImageLink);
                                """;
            const string PK_SQL = """
                                   SELECT ActorID FROM actor WHERE rowid = last_insert_rowid();
                                   """;
            int id = -1;
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            using (SQLiteCommand pkCmd = new SQLiteCommand(PK_SQL, _connection))
            {
                // Form the SQL query using data from the user
                cmd.Parameters.AddWithValue("@FirstName", actor.FirstName);
                cmd.Parameters.AddWithValue("@LastName", actor.LastName);
                cmd.Parameters.AddWithValue("@ImageLink", actor.ImageLink);
                // Execute the SQL
                cmd.ExecuteNonQuery();
                // Get the PK
                id = Convert.ToInt32(pkCmd.ExecuteScalar());
            }
            return id;
        }

        /// <summary>
        /// Insert a movie actor entry into the movieactor table.
        /// </summary>
        /// <param name="actor">The actor who plays in the movie.</param>
        /// <param name="movie">The movie who features the actor.</param>
        /// <exception cref="ArgumentNullException">Exception thrown when the actor or movie arguments are null.</exception>
        public void InsertActorMedia(Actor actor, Movie movie)
        {
            // Validate the parameters
            if (actor == null || movie == null)
            {
                throw new ArgumentNullException("The actor or movie arguments cannot be null.");
            }
            const string SQL = """
                                INSERT INTO movieactor (ActorID, MovieID) VALUES (@ActorID, @MovieID);
                                """;
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                // Form the insert statement
                cmd.Parameters.AddWithValue("@ActorID", actor.Id);
                cmd.Parameters.AddWithValue("@MovieID", movie.MediaId);
                // Execute the insert
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Insert a tv show actor entry into the tvshowactor table.
        /// </summary>
        /// <param name="actor">The actor who plays in the tv show.</param>
        /// <param name="tvShow">The tv show who features the actor.</param>
        /// <exception cref="ArgumentNullException">Exception thrown when the actor or tvShow arguments are null.</exception>
        public void InsertActorMedia(Actor actor, TVShow tvShow)
        {
            // Validate the parameters
            if (actor == null || tvShow == null)
            {
                throw new ArgumentNullException("The actor or tvShow arguments cannot be null.");
            }
            const string SQL = """
                                INSERT INTO tvshowactor (ActorID, TVShowID) VALUES (@ActorID, @TVShowID);
                                """;
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                // Form the insert statement
                cmd.Parameters.AddWithValue("@ActorID", actor.Id);
                cmd.Parameters.AddWithValue("@TVShowID", tvShow.MediaId);
                // Execute the insert
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Insert an episode actor entry into the episodeactor table.
        /// </summary>
        /// <param name="actor">The actor who plays in the episode.</param>
        /// <param name="tvShow">The episode who features the actor.</param>
        /// <exception cref="ArgumentNullException">Exception thrown when the actor or episode arguments are null.</exception>
        public void InsertActorMedia(Actor actor, Episode episode)
        {
            // Validate the parameters
            if (actor == null || episode == null)
            {
                throw new ArgumentNullException("The actor or episode arguments cannot be null.");
            }
            const string SQL = """
                                INSERT INTO episodeactor (ActorID, EpisodeID) VALUES (@ActorID, @EpisodeID);
                                """;
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                // Form the insert statement
                cmd.Parameters.AddWithValue("@ActorID", actor.Id);
                cmd.Parameters.AddWithValue("@EpisodeID", episode.MediaId);
                // Execute the insert
                cmd.ExecuteNonQuery();
            }
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
                                INSERT INTO user (FirstName, LastName, UserName, DateOfBirth, Password)
                                VALUES (@FirstName, @LastName, @UserName, @DateOfBirth, @Password);
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
                cmd.Parameters.AddWithValue("@UserName", user.Username);
                cmd.Parameters.AddWithValue("@DateOfBirth", user.Dob.ToString("yyyy-MM-dd"));
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
        public int InsertPayment(Payment payment, int userID)
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
            const string PK_SQL = """
                                   SELECT UserID FROM user WHERE rowid = last_insert_rowid();
                                   """;
            int id = -1;
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            using (SQLiteCommand pkCmd = new SQLiteCommand(PK_SQL, _connection))
            {
                // Form the SQL query using data from the user
                cmd.Parameters.AddWithValue("@Name", payment.CardHolderName);
                cmd.Parameters.AddWithValue("@Number", payment.CreditCardNum);
                cmd.Parameters.AddWithValue("@CVV", payment.Cvv);
                cmd.Parameters.AddWithValue("@ExpDate", payment.ExpiryDate);
                cmd.Parameters.AddWithValue("@PayDate", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@UserID", userID);
                // Execute the SQL
                cmd.ExecuteNonQuery();
                // Get the PK
                id = Convert.ToInt32(pkCmd.ExecuteScalar());
            }
            return id;
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
                cmd.Parameters.AddWithValue("@Synopsis", movie.Synopsis);
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
                cmd.Parameters.AddWithValue("@Synopsis", tvShow.Synopsis);
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
        /// <returns>The EpisodeID of the episode inserted.</returns>
        public int InsertEpisode(Episode episode)
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
            const string PK_SQL = """
                                   SELECT EpisodeID FROM episode WHERE rowid = last_insert_rowid();
                                   """;
            int id = -1;
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            using (SQLiteCommand pkCmd = new SQLiteCommand(PK_SQL, _connection))
            {
                // Form the SQL statement using data from the user
                cmd.Parameters.AddWithValue("@Title", episode.Title);
                cmd.Parameters.AddWithValue("@ReleaseDate", episode.ReleaseDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Synopsis", episode.Synopsis);
                cmd.Parameters.AddWithValue("@Duration", episode.Duration);
                cmd.Parameters.AddWithValue("@SeasonNumber", episode.SeasonNumber);
                cmd.Parameters.AddWithValue("@EpisodeNumber", episode.EpisodeNumber);
                cmd.Parameters.AddWithValue("@ImageLink", episode.ImageLink);
                cmd.Parameters.AddWithValue("@TVShowID", episode.TVShowId);
                // Execute the SQL query using data from the user
                cmd.ExecuteNonQuery();
                // Get the PK
                id = Convert.ToInt32(pkCmd.ExecuteScalar());
            }
            return id;
        }

        /// <summary>
        /// Insert a review for a director.
        /// </summary>
        /// <param name="review">The review of the director.</param>
        /// <param name="director">The director being reviewed</param>
        /// <exception cref="ArgumentNullException">Exception thrown when the review or director argument is null.</exception>
        /// <returns>The ReviewID of the review inserted.</returns>
        public int InsertReview(Review review, Director director)
        {
            // Validate the parameter
            if (review == null || director == null)
            {
                throw new ArgumentNullException("The review and director arguments cannot be null.");
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
            int reviewId = -1;
            using (SQLiteCommand reviewInsCmd = new SQLiteCommand(REVIEW_INS, _connection))
            using (SQLiteCommand lastIdCmd = new SQLiteCommand(LAST_REVIEW_ID, _connection))
            using (SQLiteCommand dirReviewInsCmd = new SQLiteCommand(DIR_REVIEW_INS, _connection))
            {
                // Form the review insert SQL statement
                reviewInsCmd.Parameters.AddWithValue("@Comment", review.Comment);
                reviewInsCmd.Parameters.AddWithValue("@Rating", review.Rating);
                reviewInsCmd.Parameters.AddWithValue("@UserID", review.AuthorId);
                // Execute the insert
                reviewInsCmd.ExecuteNonQuery();
                
                // Get the ID of the inserted row
                reviewId = Convert.ToInt32(lastIdCmd.ExecuteScalar());

                // Form the director review insert SQL statement
                dirReviewInsCmd.Parameters.AddWithValue("@DirectorID", director.Id);
                dirReviewInsCmd.Parameters.AddWithValue("@ReviewID", reviewId);

                // Execute the insert
                dirReviewInsCmd.ExecuteNonQuery();
            }
            return reviewId;
        }

        /// <summary>
        /// Insert a review for an actor.
        /// </summary>
        /// <param name="review">The review of the actor.</param>
        /// <param name="actor">The actor being reviewed</param>
        /// <exception cref="ArgumentNullException">Exception thrown when the review or actor argument is null.</exception>
        /// <returns>The ReviewID of the review inserted.</returns>
        public int InsertReview(Review review, Actor actor)
        {
            // Validate the parameter
            if (review == null || actor == null)
            {
                throw new ArgumentNullException("The review and actor arguments cannot be null.");
            }
            const string REVIEW_INS = """
                                       INSERT INTO review (Comment, Rating, UserID)
                                       VALUES (@Comment, @Rating, @UserID);
                                       """;
            const string LAST_REVIEW_ID = """
                                           SELECT ReviewID FROM review WHERE rowid = last_insert_rowid();
                                           """;
            const string ACT_REVIEW_INS = """
                                           INSERT INTO actorreview (ActorID, ReviewID)
                                           VALUES (@ActorID, @ReviewID);
                                           """;
            int reviewId = -1;
            using (SQLiteCommand reviewInsCmd = new SQLiteCommand(REVIEW_INS, _connection))
            using (SQLiteCommand lastIdCmd = new SQLiteCommand(LAST_REVIEW_ID, _connection))
            using (SQLiteCommand actReviewInsCmd = new SQLiteCommand(ACT_REVIEW_INS, _connection))
            {
                // Form the review insert SQL statement
                reviewInsCmd.Parameters.AddWithValue("@Comment", review.Comment);
                reviewInsCmd.Parameters.AddWithValue("@Rating", review.Rating);
                reviewInsCmd.Parameters.AddWithValue("@UserID", review.AuthorId);
                // Execute the insert
                reviewInsCmd.ExecuteNonQuery();

                // Get the ID of the inserted row
                reviewId = Convert.ToInt32(lastIdCmd.ExecuteScalar());

                // Form the director review insert SQL statement
                actReviewInsCmd.Parameters.AddWithValue("@ActorID", actor.Id);
                actReviewInsCmd.Parameters.AddWithValue("@ReviewID", reviewId);

                // Execute the insert
                actReviewInsCmd.ExecuteNonQuery();
            }
            return reviewId;
        }

        /// <summary>
        /// Insert a review for a movie.
        /// </summary>
        /// <param name="review">The review of the movie.</param>
        /// <param name="movie">The movie being reviewed</param>
        /// <exception cref="ArgumentNullException">Exception thrown when the review or movie argument is null.</exception>
        /// <returns>The ReviewID of the review inserted.</returns>
        public int InsertReview(Review review, Movie movie)
        {
            // Validate the parameter
            if (review == null || movie == null)
            {
                throw new ArgumentNullException("The review and movie arguments cannot be null.");
            }
            const string REVIEW_INS = """
                                       INSERT INTO review (Comment, Rating, UserID)
                                       VALUES (@Comment, @Rating, @UserID);
                                       """;
            const string LAST_REVIEW_ID = """
                                           SELECT ReviewID FROM review WHERE rowid = last_insert_rowid();
                                           """;
            const string MOVIE_REVIEW_INS = """
                                           INSERT INTO moviereview (MovieID, ReviewID)
                                           VALUES (@MovieID, @ReviewID);
                                           """;
            int reviewId = -1;
            using (SQLiteCommand reviewInsCmd = new SQLiteCommand(REVIEW_INS, _connection))
            using (SQLiteCommand lastIdCmd = new SQLiteCommand(LAST_REVIEW_ID, _connection))
            using (SQLiteCommand movieReviewInsCmd = new SQLiteCommand(MOVIE_REVIEW_INS, _connection))
            {
                // Form the review insert SQL statement
                reviewInsCmd.Parameters.AddWithValue("@Comment", review.Comment);
                reviewInsCmd.Parameters.AddWithValue("@Rating", review.Rating);
                reviewInsCmd.Parameters.AddWithValue("@UserID", review.AuthorId);
                // Execute the insert
                reviewInsCmd.ExecuteNonQuery();

                // Get the ID of the inserted row
                reviewId = Convert.ToInt32(lastIdCmd.ExecuteScalar());

                // Form the director review insert SQL statement
                movieReviewInsCmd.Parameters.AddWithValue("@MovieID", movie.MediaId);
                movieReviewInsCmd.Parameters.AddWithValue("@ReviewID", reviewId);

                // Execute the insert
                movieReviewInsCmd.ExecuteNonQuery();
            }
            return reviewId;
        }

        /// <summary>
        /// Insert a review for a tv show.
        /// </summary>
        /// <param name="review">The review of the tv show.</param>
        /// <param name="tvShow">The tv show being reviewed</param>
        /// <exception cref="ArgumentNullException">Exception thrown when the review or tv show argument is null.</exception>
        /// <returns>The ReviewID of the review inserted.</returns>
        public int InsertReview(Review review, TVShow tvShow)
        {
            // Validate the parameter
            if (review == null || tvShow == null)
            {
                throw new ArgumentNullException("The review and movie arguments cannot be null.");
            }
            const string REVIEW_INS = """
                                       INSERT INTO review (Comment, Rating, UserID)
                                       VALUES (@Comment, @Rating, @UserID);
                                       """;
            const string LAST_REVIEW_ID = """
                                           SELECT ReviewID FROM review WHERE rowid = last_insert_rowid();
                                           """;
            const string MOVIE_REVIEW_INS = """
                                           INSERT INTO tvshowreview (TVShowID, ReviewID)
                                           VALUES (@TVShowID, @ReviewID);
                                           """;
            int reviewId = -1;
            using (SQLiteCommand reviewInsCmd = new SQLiteCommand(REVIEW_INS, _connection))
            using (SQLiteCommand lastIdCmd = new SQLiteCommand(LAST_REVIEW_ID, _connection))
            using (SQLiteCommand showReviewInsCmd = new SQLiteCommand(MOVIE_REVIEW_INS, _connection))
            {
                // Form the review insert SQL statement
                reviewInsCmd.Parameters.AddWithValue("@Comment", review.Comment);
                reviewInsCmd.Parameters.AddWithValue("@Rating", review.Rating);
                reviewInsCmd.Parameters.AddWithValue("@UserID", review.AuthorId);
                // Execute the insert
                reviewInsCmd.ExecuteNonQuery();

                // Get the ID of the inserted row
                reviewId = Convert.ToInt32(lastIdCmd.ExecuteScalar());

                // Form the director review insert SQL statement
                showReviewInsCmd.Parameters.AddWithValue("@TVShowID", tvShow.MediaId);
                showReviewInsCmd.Parameters.AddWithValue("@ReviewID", reviewId);

                // Execute the insert
                showReviewInsCmd.ExecuteNonQuery();
            }
            return reviewId;
        }

        /// <summary>
        /// Insert a review for an episode.
        /// </summary>
        /// <param name="review">The review of the episode.</param>
        /// <param name="episode">The episode being reviewed</param>
        /// <exception cref="ArgumentNullException">Exception thrown when the review or episode argument is null.</exception>
        /// <returns>The ReviewID of the review inserted.</returns>
        public int InsertReview(Review review, Episode episode)
        {
            // Validate the parameter
            if (review == null || episode == null)
            {
                throw new ArgumentNullException("The review and episode arguments cannot be null.");
            }
            const string REVIEW_INS = """
                                       INSERT INTO review (Comment, Rating, UserID)
                                       VALUES (@Comment, @Rating, @UserID);
                                       """;
            const string LAST_REVIEW_ID = """
                                           SELECT ReviewID FROM review WHERE rowid = last_insert_rowid();
                                           """;
            const string EPISODE_REVIEW_INS = """
                                           INSERT INTO episodereview (EpisodeID, ReviewID)
                                           VALUES (@EpisodeID, @ReviewID);
                                           """;
            int reviewId = -1;
            using (SQLiteCommand reviewInsCmd = new SQLiteCommand(REVIEW_INS, _connection))
            using (SQLiteCommand lastIdCmd = new SQLiteCommand(LAST_REVIEW_ID, _connection))
            using (SQLiteCommand epReviewInsCmd = new SQLiteCommand(EPISODE_REVIEW_INS, _connection))
            {
                // Form the review insert SQL statement
                reviewInsCmd.Parameters.AddWithValue("@Comment", review.Comment);
                reviewInsCmd.Parameters.AddWithValue("@Rating", review.Rating);
                reviewInsCmd.Parameters.AddWithValue("@UserID", review.AuthorId);
                // Execute the insert
                reviewInsCmd.ExecuteNonQuery();

                // Get the ID of the inserted row
                reviewId = Convert.ToInt32(lastIdCmd.ExecuteScalar());

                // Form the director review insert SQL statement
                epReviewInsCmd.Parameters.AddWithValue("@EpisodeID", episode.MediaId);
                epReviewInsCmd.Parameters.AddWithValue("@ReviewID", reviewId);

                // Execute the insert
                epReviewInsCmd.ExecuteNonQuery();
            }
            return reviewId;
        }

        /// <summary>
        /// Insert a genre into the genre table.
        /// </summary>
        /// <param name="genre">The genre to insert.</param>
        /// <exception cref="ArgumentNullException">Exception thrown when the genre argument is null.</exception>
        public void InsertGenre(Media.Genre genre)
        {
            const string SQL = """
                                INSERT INTO genre (GenreName) VALUES (@GenreName);
                                """;
            using (SQLiteCommand cmd = new SQLiteCommand(SQL, _connection))
            {
                // Form the genre insert statement
                cmd.Parameters.AddWithValue("@GenreName", genre.ToString().ToUpper());
                // Execute the insert
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Insert a genre to the moviegenre table.
        /// </summary>
        /// <param name="genre">The genre of the movie.</param>
        /// <param name="movie">The movie possessing the genre.</param>
        /// <exception cref="ArgumentNullException">Exception thrown when the movie argument is null.</exception>
        public void InsertGenre(Media.Genre genre, Movie movie)
        {
            if (movie == null)
            {
                throw new ArgumentNullException("The movie argument cannot be null.");
            }
            const string INS_SQL = """
                                    INSERT INTO moviegenre (GenreID, MovieID) VALUES (@GenreID, @MovieID);
                                    """;
            const string PK_SQL = """
                                   SELECT GenreID FROM genre WHERE GenreName = @GenreName;
                                   """;
            using (SQLiteCommand insCmd = new SQLiteCommand(INS_SQL, _connection))
            using (SQLiteCommand pkCmd = new SQLiteCommand(PK_SQL, _connection))
            {
                // Form the select query
                pkCmd.Parameters.AddWithValue("@GenreName", genre.ToString().ToUpper());
                // Get the pk of the genre
                int genreId = Convert.ToInt32(pkCmd.ExecuteScalar());

                // Form the insert statement
                insCmd.Parameters.AddWithValue("@GenreID", genreId);
                insCmd.Parameters.AddWithValue("@MovieID", movie.MediaId);
                // Execute the insert statement
                insCmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Insert a genre to the tvshowgenre table.
        /// </summary>
        /// <param name="genre">The genre of the tv show.</param>
        /// <param name="tvShow">The tv show possessing the genre.</param>
        /// <exception cref="ArgumentNullException">Exception thrown when the tvShow argument is null.</exception>
        public void InsertGenre(Media.Genre genre, TVShow tvShow)
        {
            if (tvShow == null)
            {
                throw new ArgumentNullException("The tvShow argument cannot be null.");
            }
            const string INS_SQL = """
                                    INSERT INTO tvshowgenre (GenreID, TVShowID) VALUES (@GenreID, @TVShowID);
                                    """;
            const string PK_SQL = """
                                   SELECT GenreID FROM genre WHERE GenreName = @GenreName;
                                   """;
            using (SQLiteCommand insCmd = new SQLiteCommand(INS_SQL, _connection))
            using (SQLiteCommand pkCmd = new SQLiteCommand(PK_SQL, _connection))
            {
                // Form the select query
                pkCmd.Parameters.AddWithValue("@GenreName", genre.ToString().ToUpper());
                // Get the pk of the genre
                int genreId = Convert.ToInt32(pkCmd.ExecuteScalar());

                // Form the insert statement
                insCmd.Parameters.AddWithValue("@GenreID", genreId);
                insCmd.Parameters.AddWithValue("@TVShowID", tvShow.MediaId);
                // Execute the insert statement
                insCmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Insert a genre to the episodeGenre table.
        /// </summary>
        /// <param name="genre">The genre of the episode.</param>
        /// <param name="episode">The episode possessing the genre.</param>
        /// <exception cref="ArgumentNullException">Exception thrown when the episode argument is null.</exception>
        public void InsertGenre(Media.Genre genre, Episode episode)
        {
            if (episode == null)
            {
                throw new ArgumentNullException("The episode argument cannot be null.");
            }
            const string INS_SQL = """
                                    INSERT INTO episodegenre (GenreID, EpisodeID) VALUES (@GenreID, @EpisodeID);
                                    """;
            const string PK_SQL = """
                                   SELECT GenreID FROM genre WHERE GenreName = @GenreName;
                                   """;
            using (SQLiteCommand insCmd = new SQLiteCommand(INS_SQL, _connection))
            using (SQLiteCommand pkCmd = new SQLiteCommand(PK_SQL, _connection))
            {
                // Form the select query
                pkCmd.Parameters.AddWithValue("@GenreName", genre.ToString().ToUpper());
                // Get the pk of the genre
                int genreId = Convert.ToInt32(pkCmd.ExecuteScalar());

                // Form the insert statement
                insCmd.Parameters.AddWithValue("@GenreID", genreId);
                insCmd.Parameters.AddWithValue("@EpisodeID", episode.MediaId);
                // Execute the insert statement
                insCmd.ExecuteNonQuery();
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
                                    DateOfBirth TEXT NOT NULL,
                                    Password TEXT NOT NULL,
                                    CONSTRAINT chk_DateOfBirthFormat CHECK (DateOfBirth LIKE '____-__-__')
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
                                    PaymentDate TEXT NOT NULL,
                                    UserID INTEGER NOT NULL,
                                    CONSTRAINT chk_CardExpirationDateFormat CHECK (CardExpirationDate LIKE '____-__-00'),
                                    CONSTRAINT chk_PaymentDateFormat CHECK (PaymentDate LIKE '____-__-__'),
                                    CONSTRAINT chk_CardExpirationDateFuture CHECK (CardExpirationDate > CURRENT_DATE),
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
                                    LastName TEXT NOT NULL,
                                    ImageLink TEXT NOT NULL
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
                                    LastName TEXT NOT NULL,
                                    ImageLink TEXT NOT NULL
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
                                    CONSTRAINT chk_RatingDecimal CHECK (Rating = ROUND(Rating, 1)),
                                    CONSTRAINT chk_RatingRange CHECK (Rating BETWEEN 0 AND 5),
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
