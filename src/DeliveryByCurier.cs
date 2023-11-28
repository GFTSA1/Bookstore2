using Bookstore.src.Interfaces;
using BookStore.src;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore
{
    public class DeliveryByCurier : DeliveryParent
    {
        public String Address { get; set; }
        DeliveryByCurier() : base() 
        { }
    }
}
