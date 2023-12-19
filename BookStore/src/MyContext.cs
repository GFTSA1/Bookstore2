using Bookstore.src;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.src
{
    public class MyContext : DbContext
    {
        public MyContext() { }

        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {

        }

        public DbSet<Author> Authors { get; set; } = null!;

        public DbSet<Client> Clients { get; set; } = null!;

        public DbSet<Book> Books { get; set; } = null!;

        public DbSet<PublishingHouse> PublishingHouses { get; set; } = null!;
        public DbSet<Edition> Editions { get; set; } = null!;

        public DbSet<Item> items { get; set; } = null!;

        public DbSet<ShoppingCart> ShoppingCarts { get; set; } = null!;

        public DbSet<DeliveryParent> DeliveryParents { get; set; } = null!;
        public DbSet<DeliveryByCurier> DeliveryByCuriers { get; set; } = null!;

        public DbSet<DeliveryToPostOffice> DeliveryToPostOffices { get; set; } = null!;

        public DbSet<BookStore> BookStores { get; set; } = null!;

        public IQueryable<Author> GetAuthorById(int id) => FromExpression(() => GetAuthorById(id));

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
               .UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasKey(a => a.Id);

            modelBuilder.Entity<Client>().Property(a => a.FirstName).HasMaxLength(100);
            modelBuilder.Entity<Client>().Property(a => a.LastName).HasDefaultValue("White");

            modelBuilder.Entity<Item>().ToTable(i => i.HasCheckConstraint("Count", "Count > 0").HasName("CountOfItemsMoreThanZero"));
            modelBuilder.Entity<Item>()
                .HasOne(i => (Edition)i.Product)
                .WithMany(a => a.Items)
                .HasForeignKey(i => i.Id);

            modelBuilder.Entity<ShoppingCart>().HasKey(s => s.Id);

            //modelBuilder.Entity<DeliveryToPostOffice>().HasKey(d => new { d.Id, d.OfficeNumber }); // складений ключ
            //modelBuilder.Entity<DeliveryToPostOffice>().HasAlternateKey(d => d.OfficeNumber); // альтернативний ключ

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Delivery)
                .WithOne(d => d.Order)
                .HasForeignKey<DeliveryParent>(d => d.Id);


            modelBuilder.Entity<Client>().HasData
                (
                    new Client { Id = 1, FirstName = "Julia", LastName = "Fox", DateOfBirth = new DateTime(), PhoneNumber = "+380669943222" },
                    new Client { Id = 2, FirstName = "James", LastName = "Black", DateOfBirth = new DateTime(), PhoneNumber = "+380661233222" }
                );



            modelBuilder.HasDbFunction(() => GetAuthorById(default));
        }
    }
}
