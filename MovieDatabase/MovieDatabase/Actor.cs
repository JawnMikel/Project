using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase
{
    public class Actor
    {
        public int ActorId { get; set; }
        public List<Media> Media {  get; set; }

        public Actor(int actorId, List<Media> media)
        {
            ActorId = actorId;
            Media = media;
        }
    }
}
