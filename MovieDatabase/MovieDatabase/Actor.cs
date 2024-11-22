using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase
{
    public class Actor : CrewMember
    {
        public int ActorId { get; set; }
        public List<Media> Media {  get; set; }

        public Actor(string firstName, string secondName, List<Review> reviews, int actorId, List<Media> media) : base(firstName, secondName, reviews)
        {
            ActorId = actorId;
            Media = media;
        }
    }
}
