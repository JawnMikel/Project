﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase
{
    public abstract class Person 
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }

        protected Person(string firstName, string secondName)
        {
            FirstName = firstName;
            SecondName = secondName;
        }
    }
}