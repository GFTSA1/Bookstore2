using Bookstore.src;
using Bookstore.src.Interfaces;
using BookStore.src;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore
{
    public enum orderStatus { pending, done, deliveryInProgress, notPaid}
    public class Order
    {  
        public int id {  get; set; }
        public virtual Client Client {  get; set; }
        public virtual  DeliveryParent Delivery { get; set; }
        public int DeliveryId { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }

        public orderStatus Status { get; set; }

        public Order() { }
        public Order(Client client, DeliveryParent delivery )
        {
            Status = orderStatus.pending;
            Client = client;
            Delivery = delivery;
            ShoppingCart = new ShoppingCart();
        }


    }
}
