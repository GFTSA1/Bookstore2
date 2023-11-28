using Bookstore.src.Interfaces;
using BookStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.src
{
    public class Author : IHuman
    {
        public int Id { get; set; }
        public String FirstName {  get; set; }

        public String LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime? DateOfDeath { get; set; }
        
        public String Biography { get; set; }

        public String CountryOfBirth { get; set; }

        public List<Book> Books { get; set; } = new List<Book> { };

        public Author() { } 

        public Author(String firstName, String lastName, DateTime dateOfBirth, String biography,String countryOfBirth ) 
        { 
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Biography = biography;
            CountryOfBirth = countryOfBirth;
        }

    }
}
