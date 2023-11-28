using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.src.Interfaces
{
    public enum deliveryCompaines
    {
        NovaPoshta,
        UkrPoshta
    }
    public interface IDelivery
    {    
        public deliveryCompaines DeliveryCompany { get; set; }


    }
}
