using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase
{
    public abstract class CrewMember : Person
    {
        public List<Review> Reviews { get; set; }
        protected CrewMember(string firstName, string secondName,List<Review> reviews) : base(firstName, secondName)
        {
            Reviews = reviews;
        }

    }
}
