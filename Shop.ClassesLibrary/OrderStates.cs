using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ClassesLibrary
{
    public enum OrderStates 
    { 
        Pending = 0,
        Packing = 1,
        OnTheWay = 2,
        Delivered = 4,
        Cancelled = 5,
    }


}
