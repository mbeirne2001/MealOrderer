using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class OrderItems
    {
        public Dish Dish { get; set; }
        public int Quantity { get; set; }

        public OrderItems(Dish dish, int quantity)
        {
            Dish = dish;
            Quantity = quantity;
        }

    }
}
