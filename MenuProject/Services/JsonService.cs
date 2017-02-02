using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using MenuProject.Models;

namespace MenuProject.Services
{
    public static class JsonService
    {
        public static object asType(string jsonString, Type type)
        {
            if (String.IsNullOrEmpty(jsonString))
            {
                throw new ArgumentException("Invalid jsonString argument");
            }
           
            try
            {
                object o = JsonConvert.DeserializeObject(jsonString, type);
                return o;
            } catch (JsonException e)
            {
                throw new JsonException("Error deserializing Object");
            } catch (Exception ex)
            {
                throw new Exception("Error deseriealizing object");
            }
        }      
    }
}