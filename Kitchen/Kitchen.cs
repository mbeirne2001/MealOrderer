using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Kitchen
    {
        public delegate Order ProcessOrder(Menu menu, OrderRequest request);
        readonly Menu _menu;
        readonly ProcessOrder _processOrder;

        public Kitchen(Menu menu, ProcessOrder processOrder)
        {
            _menu = menu;
            _processOrder = processOrder;


        }

        public Order MakeOrder(OrderRequest request)
        {
            return _processOrder(_menu,request);
        }

    }
}
