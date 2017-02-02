using MenuProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MenuProject.Services
{
    public static class MenuService
    {
        private static readonly string destination = @"\menufiles\";

        public static List<MenuRoot> processFile(HttpPostedFileBase file)
        {
            try
            {
                bool result = HttpFileProcessingService.save(file, destination);
                if (result)
                {
                    string contents = HttpFileProcessingService.getContents(file);
                    if (contents != null)
                    {
                        List<MenuRoot> menus = (List<MenuRoot>)JsonService.asType(contents, typeof(List<MenuRoot>));
                        return menus;
                    }
                }

                return null;

            } catch (Exception e)
            {
                throw e;
            }
        }
    }
}