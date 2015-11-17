using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class OrderRequest
    {
        public string TimeOfDay { get; set; }
        public IEnumerable<DishType> DishTypes { get; set; }

        public OrderRequest(string timeOfDay, IEnumerable<DishType> types)
        {
            TimeOfDay = timeOfDay;
            DishTypes = types;
        }

        public static OrderRequest CreateOrderRequest(string input)
        {
            var inputArray = input.Split(',');
            var timeOfDay = inputArray[0].Trim().ToLower();
            var dt = inputArray.Skip(1).Select(int.Parse).ToArray();
            var types = new List<DishType>();
            foreach(int t in dt)
            {
                types.Add((DishType)t);
            }
           
            return new OrderRequest(timeOfDay, types.AsEnumerable());
        }
    }
}
