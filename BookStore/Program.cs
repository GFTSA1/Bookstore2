using Azure.Core;
using Bookstore.src;
using BookStore.src;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.Runtime;

namespace BookStore
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var builder = new ConfigurationBuilder();

            // установка пути к текущему каталогу
            builder.SetBasePath(Directory.GetCurrentDirectory());

            // получаем конфигурацию из файла appsettings.json
            builder.AddJsonFile("C:\\Users\\fixpg\\OneDrive\\Рабочий стол\\BookStore\\BookStore\\appsettings.json");

            // создаем конфигурацию
            var config = builder.Build();

            // получаем строку подключения
            String connectionString = config.GetConnectionString("MyConnection");

            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            var options = optionsBuilder.UseSqlServer(connectionString).Options;

            using (var context = new MyContext(options))
            {
                Union(context);
            }
        }
        public static void Intersection(MyContext context  )
        {
            var books = context.Books.Where(a => a.Name.StartsWith("M")).Intersect(context.Books.Where(a => a.AuthorId % 2 != 0));

            foreach (var book in books) { Console.WriteLine(book.Name + " " + book.AuthorId); }
        }

        public static void Union(MyContext context)
        {
            var books = context.Books.Where(a => a.Name.StartsWith("M")).Union(context.Books.Where(a => a.AuthorId % 2 == 0));

            foreach (var book in books) { Console.WriteLine(book.Name + " " + book.AuthorId); }
        }

        public static void Except(MyContext context)
        {
            var books = context.Books.Where(a => a.Name.StartsWith("M")).Except(context.Books.Where(a => a.AuthorId % 2 == 0));

            foreach (var book in books) { Console.WriteLine(book.Name + " " + book.AuthorId); }
        }

        public static void Join(MyContext context)
        {
            var books = context.Books.Join(context.Authors,
                                            b => b.AuthorId,
                                            a => a.Id,
                                            (b, a) => new
                                            {
                                                b.Name,
                                                b.Genre,
                                                a.FirstName,
                                                a.LastName,
                                                a.CountryOfBirth
                                            }
                );
            foreach (var item in books) 
            {
                Console.WriteLine($"{item.Name} {item.Genre} {item.FirstName} {item.LastName}");
            }
        }

        public static void Distinct(MyContext context)
        {
            var booksCountry = context.Authors.Select(a => a.CountryOfBirth).Distinct().ToList();

            foreach (var country in booksCountry) { Console.WriteLine(country); }
        }

        public static void GroupByCount(MyContext context)
        {
            var lst = context.Books
                .GroupBy(o => o.AuthorId)
                .Select(s => new { Key = s.Key, Count = s.Count() });

            foreach (var item in lst) Console.WriteLine(item);
        }

        public static void MaxMinFunctions(MyContext context)
        {
            int maxId = context.Books.Max(o => o.AuthorId);
            int minId = context.Books.Min(o => o.AuthorId);
        }

        public static void EagerLoading(MyContext context)
        {
            var bookAuthor = context.Books.Include(b => b.Author).ToList();
            foreach (var item in bookAuthor)
            {
                Console.WriteLine($"{item.Name} by {item.Author.FirstName} {item.Author.LastName}");
            }
        }

        public static void ExplicitLoading(MyContext context) 
        {

            var author = context.Authors.FirstOrDefault();
            context.Books.Where(b => b.AuthorId == author.Id).Load();

            Console.WriteLine($"Author: {author.FirstName} {author.LastName}");
            Console.WriteLine("Books:");
            foreach(var item in author.Books) Console.WriteLine(item.Name);



        }

        public static void LazyLoading(MyContext context)
        {
            var book = context.Books.FirstOrDefault();
            Console.WriteLine(book.Author.FirstName);
        }

        public static void NoTracking(MyContext context)
        {
            var client = context.Clients.AsNoTracking().FirstOrDefault();


            Console.WriteLine(client.FirstName + " " + client.LastName);

            client.FirstName = "Oleg";
            client.LastName = "Sunny";

            context.SaveChanges();

            Console.WriteLine(context.Clients.FirstOrDefault().FirstName + " " + context.Clients.FirstOrDefault().LastName);
        }

        public static void InvokeSavedFunction(MyContext context)
        {
            var authors = context.GetAuthorById(2).FirstOrDefault();
            Console.WriteLine(authors.FirstName + " " + authors.LastName);
        }

        public static void InvokeSavedProcedure(MyContext context)
        {
            SqlParameter param = new()
            {
                ParameterName = "@id",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output,
            };
            context.Database.ExecuteSqlRaw("GetMaxAuthorId @id OUT", param);
            Console.WriteLine(param.Value);
        }

        //Кількість авторів >3 книжок
        public static void SelectAuthors(MyContext context)
        {
            var count = context.Books
                .GroupBy(o => o.AuthorId)
                .Select(s => new { Key = s.Key, Count = s.Count() })
                .Where(a => a.Count > 3)
                .Count();

            Console.WriteLine(count);
        }
    }


}