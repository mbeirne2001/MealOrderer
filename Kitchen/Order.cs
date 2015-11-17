using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Order
    {
        List<OrderItems> _items;

        public Order(List<OrderItems> orderItems)
        {
            _items = orderItems;
        }
        public IEnumerable<OrderItems> Items
        {
            get
            {
                return _items.OrderBy(i => i.Dish.dishOrder);
            }
        }

        public void AddItems(OrderItems item)
        {
            _items.Add(item);
        }

        internal OrderItems FindDish(Dish selectedItem)
        {
            return _items.Find(o => o.Dish.DishName == selectedItem.DishName);
        }
    }
}
