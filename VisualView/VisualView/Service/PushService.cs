using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VisualView.Model;
using Newtonsoft.Json;

namespace VisualView.Service
{
    public class PushService
    {
        public static async Task<UserDetails[]> GetUserDetails()
        {
            UserDetails[] colUserDetails = null;
            try
            {
                var client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(Genaral.Comman.AppURL + "users");
                colUserDetails = JsonConvert.DeserializeObject<UserDetails[]>(response.Content.ReadAsStringAsync().Result);
            }
            catch(Exception ex)
            {

            }
            return colUserDetails;
        }
        public static async Task<UserDetails> SaveUserDetails(UserDetails oUserDetails)
        {
            UserDetails colUserDetails = null;
            try
            {
                var client = new HttpClient();
                var json = JsonConvert.SerializeObject(oUserDetails);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(Genaral.Comman.AppURL + "user",content);
                var data = response.Content.ReadAsStringAsync();
                colUserDetails = JsonConvert.DeserializeObject<UserDetails>(response.Content.ReadAsStringAsync().Result);
            }
            catch (Exception ex)
            {

            }
            return colUserDetails;
        }

        public static async Task<UserDetails> UpdateUserDetails(UserDetails oUserDetails)
        {
            UserDetails colUserDetails = null;
            try
            {
                var client = new HttpClient();
                var json = JsonConvert.SerializeObject(oUserDetails);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync(Genaral.Comman.AppURL + "user", content);
                var data = response.Content.ReadAsStringAsync();
                colUserDetails = JsonConvert.DeserializeObject<UserDetails>(response.Content.ReadAsStringAsync().Result);
            }
            catch (Exception ex)
            {

            }
            return colUserDetails;
        }
    }
}
