using MenuProject.Models;
using MenuProject.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MenuProject.Controllers
{
    public class MenuController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult upload()
        {
            JsonResponse response = new JsonResponse();
            List<MenuRoot> menus = new List<MenuRoot>();

            try
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];
                    menus.AddRange(MenuService.processFile(file));
                }
                response.success(menus);
            } catch (Exception e)
            {
                response.fail(e.Message);
            }        

            return Json(response);
        }
    }
}