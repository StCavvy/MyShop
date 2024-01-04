using Shop.ClassesLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public int ProductCounts { get; set; }

        public List<int> ProductsId = new List<int>();
        public int PackerId { get; set; }
        public OrderStates OrderState { get; set; }
        public decimal TotalPrice { get; set; }
        public string? PackerName { get; set; }
        public string? UserName { get; set; }

    }
}
