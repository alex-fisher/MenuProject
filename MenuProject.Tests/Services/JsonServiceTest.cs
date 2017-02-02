using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MenuProject.Services;
using MenuProject.Models;
using Newtonsoft.Json;
using System.IO;

namespace MenuProject.Tests.Services
{
    [TestClass]
    public class JsonServiceTest
    {
        [TestMethod]
        public void asType_WithValidJson_ReturnsMenus()
        {
            List<MenuRoot> expected = new List<MenuRoot>();
            MenuRoot root = new MenuRoot();
            Menu menu = new Menu();

            root.menu = menu;

            MenuItem item = new MenuItem();
            item.id = 27;

            MenuItem item1 = new MenuItem();
            item1.id = 0;
            item1.label = "Label 0";

            MenuItem[] items = new MenuItem[3];
            items[0] = item;
            items[1] = item1;
            items[2] = null;

            menu.header = "menu";
            menu.items = items;
            expected.Add(root);

            string json = "";
            using (StreamReader sr = new StreamReader(@"Resources\test.json"))
            {
                json = sr.ReadToEnd();
            }

            List<MenuRoot> menus = (List<MenuRoot>) JsonService.asType(json, typeof(List<MenuRoot>));

            Assert.AreEqual(expected[0].menu.header, menus[0].menu.header);
            Assert.AreEqual(expected[0].menu.items[0].id, menus[0].menu.items[0].id);
            Assert.AreEqual(expected[0].menu.items[0].label, menus[0].menu.items[0].label);

            Assert.AreEqual(expected[0].menu.items[1].id, menus[0].menu.items[1].id);
            Assert.AreEqual(expected[0].menu.items[1].label, menus[0].menu.items[1].label);

            Assert.AreEqual(expected[0].menu.items[2], menus[0].menu.items[2]);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void asType_jsonString_ArgumentException_null()
        {
            List<MenuRoot> menus = (List<MenuRoot>)JsonService.asType(null, typeof(List<MenuRoot>));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void asType_jsonString_ArgumentException_blank()
        {
            List<MenuRoot> menus = (List<MenuRoot>)JsonService.asType("", typeof(List<MenuRoot>));
        }

        [TestMethod]
        [ExpectedException(typeof(JsonException))]
        public void asType_jsonString_JsonException_Malformed()
        {
            List<MenuRoot> menus = (List<MenuRoot>)JsonService.asType("{[]}", typeof(List<MenuRoot>));
        }
    }
}
