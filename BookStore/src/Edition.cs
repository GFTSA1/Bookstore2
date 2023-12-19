using Bookstore.src;
using Bookstore.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore
{
    public enum coverTypesEnum
    {
        Soft,
        Hard
    }
    public class Edition : IProduct
    {
        public int Id { get; set; }

        private String _name;
        private int _pagesCount;
        private int _yearOfPublishing;
        public virtual Book Book { get; set; }
        public int BookId {  get; set; }

        public virtual PublishingHouse PublishingHouse { get; set; }
        public int PublishingHouseId { get; set; }
        public coverTypesEnum TypeOfCover { get; set; }

        public String Name
        {
            get
            {
                return Book.Name + " " + _name;
            }
            set { _name = value; }

        }

        public int PagesCount
        {
            get
            {
                return _pagesCount;
            }
            set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException("Кількість сторінок має бути більшою за 0");
                else _pagesCount = value;
            }
        }

        public int YearOfPublishing
        {
            get
            {
                return _yearOfPublishing;
            }
            set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException("Рік видання не може бути < 0");
                else _yearOfPublishing = value;
            }
        }

        public int Price { get; set; }

        public virtual List<Item> Items { get; set; } = new List<Item>();
        public Edition() { }
        public Edition(String name, int pagesCount, int yearOfPublishing, Book book,
                        PublishingHouse publishingHouse, coverTypesEnum typeOfCover)
        {
            this.Name = name;
            this.PagesCount = pagesCount;
            this.YearOfPublishing = yearOfPublishing;
            this.Book = book;
            this.PublishingHouse = publishingHouse;
            this.TypeOfCover = typeOfCover;
        }
    }
}
