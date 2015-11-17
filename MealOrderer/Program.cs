using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant;

namespace MealOrderer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter time of day and dish codes or press ECS to close:");
                var kitchen = CreateKitchen();
                while (true)
                {
                    Console.Write("Input:");

                    var input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(input))
                        break;

                    var orderRequest = OrderRequest.CreateOrderRequest(input);
                    var order = kitchen.MakeOrder(orderRequest);
                    Console.WriteLine("Output: {0}",
                                       string.Join(",", order.Items.Select(GetOrderItemFormat)));



                }

            }
            catch(Exception ex)
            {
                Console.WriteLine("Error occurred: {0}", ex.Message);
            }
        }

        public static string GetOrderItemFormat(OrderItems item)
        {
            return string.Format("{0}{1}", item.Dish.DishName.ToLower(),
                                 item.Quantity > 1 ? string.Format("(x{0})", item.Quantity) : "");
        }

        private static Kitchen CreateKitchen()
        {
            var breakfast = new List<MenuItem> { new MenuItem(new Dish("eggs",DishType.Entree,1),false),
                                            new MenuItem(new Dish("Toast", DishType.Side,2), false),
                                            new MenuItem(new Dish("coffee",DishType.Drink,3), true) };
            var dinner = new List<MenuItem> { new MenuItem(new Dish("steak", DishType.Entree,1)),
                                              new MenuItem(new Dish("potato", DishType.Side,2),true),
                                              new MenuItem(new Dish("wine", DishType.Drink,3)),
                                              new MenuItem(new Dish("cake",DishType.Dessert,4))};
            var restaurantMenu = new Dictionary<string, IEnumerable<MenuItem>> { { "morning", breakfast }, { "night", dinner } };
            return new Kitchen(new Menu(restaurantMenu), new OrderManager().ProcessRequest);

        }
    }
}
