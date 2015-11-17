using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant;
using System.Linq;

namespace RestaurantTests
{
    [TestClass]
    public class OrderRequestTests
    {
        [TestMethod]
        public void CorrectMorningOrders()
        {
            OrderRequest or = OrderRequest.CreateOrderRequest("morning,1,3,2");
            Assert.IsNotNull(or);
            Assert.IsTrue(or.TimeOfDay.Equals("morning"));
            Assert.IsTrue(or.DishTypes.Count() == 3);
            Assert.IsTrue(or.DishTypes.Contains(DishType.Entree));
            Assert.IsTrue(or.DishTypes.Contains(DishType.Side));
            Assert.IsTrue(or.DishTypes.Contains(DishType.Drink));


        }

        [TestMethod]
        public void CorrectNightOrders()
        {
            OrderRequest or = OrderRequest.CreateOrderRequest("night,1,3,2,4");
            Assert.IsNotNull(or);
            Assert.IsTrue(or.TimeOfDay.Equals("night"));
            Assert.IsTrue(or.DishTypes.Count() == 4);
            Assert.IsTrue(or.DishTypes.Contains(DishType.Entree));
            Assert.IsTrue(or.DishTypes.Contains(DishType.Side));
            Assert.IsTrue(or.DishTypes.Contains(DishType.Drink));
            Assert.IsTrue(or.DishTypes.Contains(DishType.Dessert));


        }
        
    }
}
