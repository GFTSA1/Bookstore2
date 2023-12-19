using Bookstore.src;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookStore
{
    public enum Genres
    {
        Drama, 
        Fantasy, 
        FairyTale, 
        TravelBooks,
        Autobiography,
        History,
        Thriller,
        Mystery,
        Romance,
        Horror,
        Business
    }

    public class Book
    {
        [Key]
        public int Id { get; set; }
        public Genres Genre { get; set; }

        [MaxLength(100)]
        public String Name { get; set; }

        public virtual Author Author { get; set; }

        [ForeignKey("AuthorId")]
        public int AuthorId { get; set; }

        public virtual List<Edition> Editions { get; set; } = new List<Edition>();


        public Book()
        { }

        public Book(Author author, Genres genre, String name)
        {
            Author = author;
            Genre = genre;
            Name = name;
        }
    }
}
