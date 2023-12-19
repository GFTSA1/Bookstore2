using Bookstore.src.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.src
{
    public  class DeliveryParent : IDelivery
    {
        public int Id { get; set; }
        public deliveryCompaines DeliveryCompany { get; set; }

        public virtual Order Order { get; set; }
        
        [ForeignKey("OrderId")]
        public int OrderId { get; set; }

        public DeliveryParent() { }
    }
}
