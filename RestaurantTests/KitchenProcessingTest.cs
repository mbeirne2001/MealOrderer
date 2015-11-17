using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant;
using System.Linq;
using System.Collections.Generic;

namespace RestaurantTests
{
    [TestClass]
    public class KitchenProcessingTest
    {
        private Kitchen kitchen;

        [TestInitialize]
        public void CreateKitchen()
        {
            var breakfast = new List<MenuItem> { new MenuItem(new Dish("eggs",DishType.Entree,1),false),
                                            new MenuItem(new Dish("Toast", DishType.Side,2), false),
                                            new MenuItem(new Dish("coffee",DishType.Drink,3), true) };
            var dinner = new List<MenuItem> { new MenuItem(new Dish("steak", DishType.Entree,1)),
                                              new MenuItem(new Dish("potato", DishType.Side,2),true),
                                              new MenuItem(new Dish("wine", DishType.Drink,3)),
                                              new MenuItem(new Dish("cake",DishType.Dessert,4))};
            var restaurantMenu = new Dictionary<string, IEnumerable<MenuItem>> { { "morning", breakfast }, { "night", dinner } };
            kitchen = new Kitchen(new Menu(restaurantMenu), new OrderManager().ProcessRequest);

        }
        [TestMethod]
        public void CorrectMorningRequest()
        {
            OrderRequest or = OrderRequest.CreateOrderRequest("morning,1,3,2");
            var order = kitchen.MakeOrder(or);

            Assert.IsNotNull(order);
            Assert.IsTrue(order.Items.Count() == 3);
            Assert.IsTrue(order.Items.First().Dish.DishName.Equals("eggs"));
            Assert.IsTrue(order.Items.Skip(1).FirstOrDefault().Dish.DishName.Equals("toast"));
            Assert.IsTrue(order.Items.Skip(2).FirstOrDefault().Dish.DishName.Equals("coffee"));

        }

        [TestMethod]
        public void CorrectDinnerRequest()
        {
            OrderRequest or = OrderRequest.CreateOrderRequest("night,1,3,4,2");
            var order = kitchen.MakeOrder(or);

            Assert.IsNotNull(order);
            Assert.IsTrue(order.Items.Count() == 4);
            Assert.IsTrue(order.Items.First().Dish.DishName.Equals("steak"));
            Assert.IsTrue(order.Items.Skip(1).FirstOrDefault().Dish.DishName.Equals("potato"));
            Assert.IsTrue(order.Items.Skip(2).FirstOrDefault().Dish.DishName.Equals("wine"));
            Assert.IsTrue(order.Items.Skip(3).FirstOrDefault().Dish.DishName.Equals("cake"));

        }

        [TestMethod]
        public void CorrectDinnerRequestWithMultiples()
        {
            OrderRequest or = OrderRequest.CreateOrderRequest("night,1,3,4,2,2,2");
            var order = kitchen.MakeOrder(or);

            Assert.IsNotNull(order);
            Assert.IsTrue(order.Items.Count() == 4);
            Assert.IsTrue(order.Items.First().Dish.DishName.Equals("steak"));
            Assert.IsTrue(order.Items.Skip(1).FirstOrDefault().Dish.DishName.Equals("potato"));
            Assert.IsTrue(order.Items.Skip(1).FirstOrDefault().Quantity.Equals(3));
            Assert.IsTrue(order.Items.Skip(2).FirstOrDefault().Dish.DishName.Equals("wine"));
            Assert.IsTrue(order.Items.Skip(3).FirstOrDefault().Dish.DishName.Equals("cake"));

        }
        [TestMethod]
        public void IncorrectMorningRequest()
        {
            OrderRequest or = OrderRequest.CreateOrderRequest("morning,1,4,2");
            var order = kitchen.MakeOrder(or);

            Assert.IsNotNull(order);
            Assert.IsTrue(order.Items.Count() == 3);
            Assert.IsTrue(order.Items.First().Dish.DishName.Equals("eggs"));
            Assert.IsTrue(order.Items.Skip(2).FirstOrDefault().Dish.DishName.Equals("error"));
            
        }

        [TestMethod]
        public void IncorrectMultipleRequest()
        {
            OrderRequest or = OrderRequest.CreateOrderRequest("morning,1,3,2,2,2");
            var order = kitchen.MakeOrder(or);

            Assert.IsNotNull(order);
            Assert.IsTrue(order.Items.Count() == 3);
            Assert.IsTrue(order.Items.First().Dish.DishName.Equals("eggs"));
            Assert.IsTrue(order.Items.Skip(2).FirstOrDefault().Dish.DishName.Equals("error"));

        }
    }
}
