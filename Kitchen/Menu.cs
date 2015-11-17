using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Menu
    {
        readonly Dictionary<string, IEnumerable<MenuItem>> _menuItems;

        public Menu(Dictionary<string, IEnumerable<MenuItem>> menuItems)
        {
            _menuItems = menuItems;
        }

        public IEnumerable<MenuItem> GetMenuItems(string mealTime)
        {
            if (!_menuItems.ContainsKey(mealTime))
                return null;
            return _menuItems[mealTime];
        }

        
    }
}
