﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase
{
    public class User
    {
        private static int nextId = 1;
        public int Id { get; set; }
        private string _username;
        private string _password;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public enum Memberships
        {
            REGULAR,
            PREMIUM
        }
        public Memberships Membership { get; set; }

        public User(string username, string password, string firstName, string lastName, Memberships membership, DateTime dob)
        {
            Id = nextId++;
            _username = username;
            _password = password;
            FirstName = firstName;
            LastName = lastName;
            Membership = membership;
            Dob = dob;
        }

        /// <summary>
        /// passes a username and password and checks if they match with the fields of the user
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="password">password</param>
        /// <returns>true if the credentials match or returns false if the credentials do not match</returns>
        public bool CheckCredentials(string username, string password)
        {
            return _username == username && _password == password;
        }

    }
}
