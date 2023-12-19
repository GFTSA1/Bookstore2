using Bookstore.src;
using Bookstore.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore
{
    public class ShoppingCart
    {
        public int Id { get; set; }

        public delegate void StringDelegate(string message);

        public StringDelegate? AddProductToCartDelegate;
        
        public event StringDelegate AddProductEvent
        {  
            add
            {
                AddProductToCartDelegate += value;
            }
            remove 
            {
                AddProductToCartDelegate -= value;
            }
        
        }

        public virtual List<Item> AddedItemsList { get; set; }

        public int TotalPrice { get; set; }
        public void addProduct(Item itemToAdd)
        {
            AddedItemsList.Add(itemToAdd);
            TotalPrice += itemToAdd.Product.Price * itemToAdd.Count;
            if (AddProductToCartDelegate != null)
            {
                AddProductToCartDelegate.Invoke("Product added to your cart:" + itemToAdd.Product.Name + " Count: " + itemToAdd.Count);
            }
        }

        public ShoppingCart()
        {

        }
    }
}
