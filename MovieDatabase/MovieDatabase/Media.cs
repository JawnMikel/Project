using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MovieDatabase
{
    public abstract class Media
    {
        public int MediaId { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<Director> Directors { get; set; }
        public List<Actor> Actors { get; set; }
        public Genre Genres { get; set; }
        public List<Review> Reviews { get; set; }
        public string Sysnopsis { get; set; }

        protected Media(int mediaId, string title, DateTime releaseDate, List<Director> directors, List<Actor> actors, Genre genres, List<Review> reviews, string sysnopsis)
        {
            MediaId = mediaId;
            Title = title;
            ReleaseDate = releaseDate;
            Directors = directors;
            Actors = actors;
            Genres = genres;
            Reviews = reviews;
            Sysnopsis = sysnopsis;
        }

        public enum Genre
        {
            ACTION,
            COMEDY,
            MYSTERY,
            HORROR,
            SCI_FI,
            ROMANCE,
            THRILLER,
            DRAMA,
            MUSICAL,
            WAR,
            SUPERHERO,
            ANIMATION,
            DOCUMENTARY,
            CRIME,
            FANTASY
        }

        public void AddReview(Review review)
        {

        }

        public double GetMediaRating()
        {
            return 0;
        }
    }
}
