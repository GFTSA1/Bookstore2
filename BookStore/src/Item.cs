using Bookstore.src.Interfaces;
using BookStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.src
{
    public class Item
    {
        public int Id { get; set; }
        public virtual IProduct Product { get; set; }
        public int ProductId { get; set; }   
        public int Count {  get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }
        public int ShoppingCartId { get; set; }

        public Item() { }   
        public Item(IProduct product, int count) 
        {
            Product = product;
            Count = count; 
        }
    }
}
