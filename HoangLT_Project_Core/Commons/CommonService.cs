using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HoangLT_Project_Core.Commons
{
    public static class CommonService
    {
        public static async Task<string> ConnectToAPI(string url, string method)
        {
            string result = string.Empty;
            using (var client = new HttpClient())
            {
                //client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = null;
                if (method == "GET")
                {
                    response = await client.GetAsync(url);

                }

                if (response != null && response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsStringAsync();
                }
            }
            //    var req = HttpWebRequest.Create(url);
            //req.Method = method;
            //req.ContentType = "application/json";

            //using (var resp = req.GetResponse())
            //{
            //    var results = new StreamReader(resp.GetResponseStream()).ReadToEnd();
            //    return results;
            //}

            return result;
        }

        public static T GetPropValue<T>(this Object obj, String name)
        {
            Object retval = GetPropValue(obj, name);
            if (retval == null) { return default(T); }

            // throws InvalidCastException if types are incompatible
            return (T)retval;
        }

        public static Object GetPropValue(this Object obj, String name)
        {
            foreach (String part in name.Split('.'))
            {
                if (obj == null) { return null; }

                Type type = obj.GetType();
                PropertyInfo info = type.GetProperty(part);
                if (info == null) { return null; }

                obj = info.GetValue(obj, null);
            }
            return obj;
        }
    }
}
