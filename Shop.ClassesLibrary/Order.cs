using Shop.ClassesLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    internal class Order
    {
        public required int ID { get; set; }
        public required int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public required int ProductsCount { get; set; }
        public required List<int> ProductsId { get; set; }
        public required int PackerId { get; set; }
        public OrderStates OrderState { get; set; }
        public decimal TotalPrice {  get; set; }

    }
}
