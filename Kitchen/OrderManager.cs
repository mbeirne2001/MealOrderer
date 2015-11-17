using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class OrderManager
    {
        private Order _order { get; set; }

        public Order ProcessRequest(Menu menu, OrderRequest request)
        {
            var orderItems = new List<OrderItems>();
            _order = new Order(orderItems);
            
            try
            {
                var selectedMenuItem = GetDishesRequestByMenu(menu, request);
                foreach (var selectedItem in selectedMenuItem)
                {
                    var itemInOrder = _order.FindDish(selectedItem.Dish);
                    if (itemInOrder != null)
                    {
                        if(selectedItem.AllowMultiples)
                            itemInOrder.Quantity++;
                        else
                        {
                            AddError();
                            break;
                        }
                    }
                    else
                    {
                        _order.AddItems(new OrderItems(selectedItem.Dish, 1));
                    }
                }

                if((selectedMenuItem.Count() != request.DishTypes.Count()) && (!HasError()))
                {
                    AddError();
                }
            }
            catch
            {
                AddError();
            }
            return _order;
        }

        private bool HasError()
        {
            var error = _order.FindDish(new Dish("error", DishType.Unknown, 5));
            return (error != null) ? true : false;
        }

        private void AddError()
        {
            Dish d = new Dish("error", DishType.Unknown, 5);
            _order.AddItems(new OrderItems(d, 1));
        }

        IEnumerable<MenuItem> GetDishesRequestByMenu(Menu menu, OrderRequest request)
        {
            var menuItems = menu.GetMenuItems(request.TimeOfDay);

            return from m in menuItems
                          join dType in request.DishTypes
                          on m.Dish.type equals dType
                          select m;
        }

    }
}
