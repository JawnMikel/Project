using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase
{
    public abstract class CrewMember : Person
    {
        private static int _counter = 1;
        public int Id { get; set; }
        public List<Review> Reviews { get; set; }
        public CrewMember(string firstName, string secondName,List<Review> reviews) : base(firstName, secondName)
        {
            Id = _counter++;
            Reviews = reviews;
        }

    }
}
