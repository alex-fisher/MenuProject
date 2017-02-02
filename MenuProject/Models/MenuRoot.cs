using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MenuProject.Models
{
    public class MenuRoot
    {
        public Menu menu { get;  set;}
 
        public MenuItem[] getValidItems()
        { 
            if (menu != null && menu.items != null)
            {
                return menu.items.Where(i => i != null && !String.IsNullOrEmpty(i.label)).ToArray();
            } else
            {
                return null;
            }
        }

        public int sum
        {
            get {
                MenuItem[] validItems = getValidItems();
                if (validItems != null && validItems.Length > 0)
                {
                    return validItems.Sum(i => i.id);
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}