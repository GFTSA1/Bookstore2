using Bookstore.src;
using BookStore.src;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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
            builder.AddJsonFile("E:\\PROG3\\appsettings.json");

            // создаем конфигурацию
            var config = builder.Build();

            // получаем строку подключения
            String connectionString = config.GetConnectionString("MyConnection");

            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            var options = optionsBuilder.UseSqlServer(connectionString).Options;

            using (var context = new MyContext(options))
            {

                var clientToAdd = new Client() { FirstName = "John", LastName = "Morgan", DateOfBirth = new DateTime(), PhoneNumber = "+380662389433" };

                context.Clients.Add(clientToAdd);
                context.SaveChanges();


                var clientToChange = context.Clients.Where(c => c.FirstName == "John").FirstOrDefault();
                if (clientToChange != null)
                {
                    clientToChange.PhoneNumber = "+380662389777";
                }
                context.SaveChanges();


                var clientToDelete = context.Clients.Where(c => c.FirstName == "Julia").FirstOrDefault();
                context.Clients.Remove(clientToDelete);
                context.SaveChanges();

                var clientss = context.Clients.ToList();

                foreach (var client in clientss)
                {
                    Console.WriteLine(client.FirstName + " " + client.PhoneNumber + "\n");
                }
            }
        }
    }
}