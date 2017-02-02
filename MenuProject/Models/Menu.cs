using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MenuProject.Models
{
    public class Menu
    {
        public string header { get; set; }
        public MenuItem[] items { get; set; }
    }
}