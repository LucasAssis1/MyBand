using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Net.Http;
using My_Band.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace My_Band.DataService
{
    public class DataServiceAPI
    {
        HttpClient client = new HttpClient();
        //string urlBase = "http://xamarinwebapi.somee.com/XamarinWebAPI/api/Home";

        public async Task<List<UserModel>> GetUsersAsync()
        {
            try
            {
                string url = "http://xamarinwebapi.somee.com/XamarinWebAPI/api/Home";
                var response = await client.GetStringAsync(url);
                var users = JsonConvert.DeserializeObject<List<UserModel>>(response);
                return users;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Boolean> AddUsersAsync(UserModel user)
        {
            try
            {
                string url = "http://xamarinwebapi.somee.com/XamarinWebAPI/api/Home";
                var data = JsonConvert.SerializeObject(user);
                var content = new StringContent(data, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                response = await client.PostAsync(url, content);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Erro ao incluir o usuário");
                }

                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateUser(UserModel user)
        {
            string url = "http://xamarinwebapi.somee.com/XamarinWebAPI/api/Home";
            var uri = new Uri(string.Format(url, user.ID));

            var data = JsonConvert.SerializeObject(user);
            var content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            response = await client.PutAsync(url, content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Erro ao atualizar o usuário!");
            }
        }

        public async Task DeleteUser(UserModel user)
        {
            string url = "http://xamarinwebapi.somee.com/XamarinWebAPI/api/Home";
            var uri = new Uri(string.Format(url, user.ID));
            await client.DeleteAsync(uri);
        }
    }
}