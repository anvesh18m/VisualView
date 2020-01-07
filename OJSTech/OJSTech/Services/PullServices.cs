using Newtonsoft.Json;
using OJSTech.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OJSTech.Services
{
    public class PullServices
    {
        public static async Task<PagesData> GetPages(int pageNo)
        {
            PagesData oPageData = null;
            try
            {
                var client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("https://hn.algolia.com/api/v1/search_by_date?tags=story&page=" + pageNo);
                oPageData = JsonConvert.DeserializeObject<PagesData>(response.Content.ReadAsStringAsync().Result);
            }
            catch(Exception ex)
            {

            }
            return oPageData;
        }
    }
}
