using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.Services
{
    public class WebApiService : IWebApiService
    {
        public async Task<List<Person>> GetPeopleAsync()
        {
            HttpWebRequest request = WebRequest.Create("http://localhost:4653/api/values") as HttpWebRequest;
            request.ContentType = "application/json";
            request.Method = "GET";
            request.ContentLength = 0;

            string responseData = string.Empty;

            HttpWebResponse res;

            try
            {
                res = await request.GetResponseAsync() as HttpWebResponse;
            }
            catch
            {
                return new List<Person>();
            }

            using (StreamReader reader = new StreamReader(res.GetResponseStream()))
            {
                responseData = reader.ReadToEnd();
                reader.Close();
            }

            res.Close();

            return JsonConvert.DeserializeObject<List<Person>>(responseData);
        }
    }
}
