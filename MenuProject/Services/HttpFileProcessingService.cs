using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MenuProject.Services
{
    public static class HttpFileProcessingService
    {
        public static bool save(HttpPostedFileBase file, string destination)
        {
            try
            {
                if (String.IsNullOrEmpty(destination))
                {
                    throw new ArgumentException("Invalid Destination");
                }

                if (!Directory.Exists(destination))
                {
                    Directory.CreateDirectory(destination);
                }

                var path = destination + file.FileName;

                using (var fileStream = File.Open(path, FileMode.Create))
                {
                    file.InputStream.CopyTo(fileStream);
                }

                return true;
            } catch (ArgumentException arg)
            {
                throw arg;
            }  catch (Exception e)
            {
                throw new Exception("Error saving uploaded file");
            }
        }

        public static string getContents(HttpPostedFileBase file)
        {
            try
            {          
                file.InputStream.Position = 0;
                using (StreamReader reader = new StreamReader(file.InputStream))
                {
                    string contents = reader.ReadToEnd();
                    return contents;
                }
            } catch (Exception e)
            {
                throw new Exception("Error getting file contents");
            }
        }

    }
}