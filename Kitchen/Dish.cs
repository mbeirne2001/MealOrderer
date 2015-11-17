using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Dish
    {
        public string DishName { get; set; }
        public DishType type { get; set; }
        public int dishOrder { get; set; }

        public Dish(string name, DishType type, int order)
        {
            this.DishName = name.ToLower();
            this.type = type;
            this.dishOrder = order;
        }
    }



    public enum DishType
    {
        Entree = 1,
        Side = 2,
        Drink = 3,
        Dessert = 4,
        Unknown = 5
    }
}
