using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PetStar.Entity;

namespace PetStar.App_Data
{
    public static class ApiHelper<T> where T : class
    {
        public static T Get(string url)
        {
            using (var client = new WebClient())
            {
                var text = client.DownloadString(url);

                return JsonConvert.DeserializeObject<List<T>>(text).FirstOrDefault();
            }
        }

        public static List<T> GetList(string url)
        {
            using (var client = new WebClient())
            {
                var text = client.DownloadString(url);

                return JsonConvert.DeserializeObject<List<T>>(text);
            }
        }
    }
}