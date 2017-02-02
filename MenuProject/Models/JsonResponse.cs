using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MenuProject.Models
{
    public class JsonResponse
    {
        public bool status { get; set; }
        public string error { get; set; }
        public object result { get; set; }

        public JsonResponse fail(string error)
        {
            status = false;
            this.error = error;
            return this;
        }

        public JsonResponse success(object result)
        {
            status = true;
            this.result = result;
            return this;
        }
    }
}