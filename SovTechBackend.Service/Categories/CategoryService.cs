
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SovTechBackend.Service.categories
{
    public class CategoryService : ICategoryService
    {
        public CategoryService(){}
        public async Task<List<string>> GetCategories()
        {
            string Baseurl = "https://api.chucknorris.io/jokes/";
            List<string> categories = new List<string>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();                
                //Sending request to find web api REST service resource Category List using HttpClient               
                HttpResponseMessage Res = await client.GetAsync("categories");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var responseData = Res.Content.ReadAsStringAsync().Result;
                    categories = JsonConvert.DeserializeObject<List<string>>(responseData);
                }
            }
            return categories;
        }

        public async Task<List<string>> SearchCategory(string query)
        {
            string Baseurl = "https://api.chucknorris.io/jokes/";
            List<string> categories = new List<string>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Sending request to find web api REST service resource Category List using HttpClient               
                HttpResponseMessage Res = await client.GetAsync("categories/?search="+query);
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var responseData = Res.Content.ReadAsStringAsync().Result;
                    categories = JsonConvert.DeserializeObject<List<string>>(responseData);
                }
            }
            return categories;
        }
    }
}
