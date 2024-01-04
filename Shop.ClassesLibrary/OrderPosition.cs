using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class OrderPosition
    {
        public required int OrderId { get; set; }

        public required int ProductId { get; set; }

    }
}
