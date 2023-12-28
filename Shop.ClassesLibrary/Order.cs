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
        public DateTime OrderDate { get; set; }
        public required int ProductsCount { get; set; }
        public required List<int> Products { get; set; }
        public required int Packer {  get; set; }

    }
}
