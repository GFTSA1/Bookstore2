using Bookstore.src.Interfaces;
using BookStore.src;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore
{
    public class DeliveryToPostOffice : DeliveryParent
    {
        public int OfficeNumber { get; set; }

        public DeliveryToPostOffice() : base() { }
    }
}
