using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class MenuItem
    {
        public Dish Dish { get; set; }
        public bool AllowMultiples { get; set; }

        public MenuItem(Dish dish, bool allowMultiples = false)
        {
            Dish = dish;
            AllowMultiples = allowMultiples;
        }

        
    }
}
