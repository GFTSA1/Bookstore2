using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.src.Interfaces
{
    public interface IProduct
    {
        public String Name { get;}

        public int Price {  get; set; }
    }
}
